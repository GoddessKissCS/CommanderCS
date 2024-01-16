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
            string session = GetSession();

            var user = GetUserGameProfile();

            bool success = false;

            string idx = @params.idx.ToString();

            if (user.CommanderData[idx] != null)
            {
                int costumeId = user.CommanderData[idx].currentCostume;

                success = DatabaseManager.GameProfile.ChangeThumbnailId(session, costumeId);

                if (user.GuildId != null)
                {
                    DatabaseManager.Guild.UpdateSpecificMemberThumbnail(user.GuildId, user.Uno, costumeId);
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