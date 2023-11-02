using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Packet(Id = Method.ChangeUserThumbnail)]
    public class ChangeThumbnail : BaseMethodHandler<ChangeThumbnailRequest>
    {
        public override object Handle(ChangeThumbnailRequest @params)
        {
#warning TODO - MISSING FALSE HANDLING

            string session = GetSession();

            bool success = DatabaseManager.GameProfile.ChangeThumbnail(session, @params.idx);

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