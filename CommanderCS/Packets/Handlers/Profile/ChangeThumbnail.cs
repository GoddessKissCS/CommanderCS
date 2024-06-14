using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Profile
{
    [Packet(Id = Method.ChangeUserThumbnail)]
    public class ChangeThumbnail : BaseMethodHandler<ChangeThumbnailRequest>
    {
        public override object Handle(ChangeThumbnailRequest @params)
        {
            bool success = false;

            string idx = @params.idx.ToString();

            if (User.CommanderData[idx] != null)
            {
                int costumeId = User.CommanderData[idx].currentCostume;

                success = DatabaseManager.GameProfile.ChangeThumbnailId(SessionId, costumeId);

                if (User.GuildId != null)
                {
                    DatabaseManager.Guild.UpdateSpecificMemberThumbnail(User.GuildId, User.Uno, costumeId);
                }
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = success.ToString()
            };

            return response;
        }
    }

    public class ChangeThumbnailRequest
    {
        [JsonProperty("idx")]
        public int idx { get; set; }
    }
}