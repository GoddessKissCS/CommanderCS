using CommanderCS.Database;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;

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

            if (user.CommanderData["" + @params.idx] != null)
            {
                success = DatabaseManager.GameProfile.ChangeThumbnailId(session, @params.idx);
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