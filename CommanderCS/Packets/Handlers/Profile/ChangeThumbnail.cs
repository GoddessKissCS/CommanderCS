using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Profile
{
    [Packet(Id = Method.ChangeUserThumbnail)]
    public class ChangeThumbnail : BaseMethodHandler<ChangeThumbnailRequest>
    {
        public override object Handle(ChangeThumbnailRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            bool success = false;

            string idx = request.idx.ToString();

            if (User.CommanderData[idx] !=null)
            {
                int costumeId = User.CommanderData[idx].currentCostume;

                success = DatabaseManager.GameProfile.ChangeThumbnailId(SessionId, costumeId);

                if (User.GuildId !=null)
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