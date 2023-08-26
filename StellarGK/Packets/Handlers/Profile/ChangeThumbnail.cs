using StellarGK.Database;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Profile
{
    [Packet(Id = MethodId.ChangeUserThumbnail)]
    public class ChangeThumbnail : BaseMethodHandler<ChangeThumbnailRequest>
    {
        public override object Handle(ChangeThumbnailRequest @params)
        {

#warning TODO - MISSING FALSE HANDLING

            bool success = DatabaseManager.GameProfile.ChangeThumbnail(GetSession(), @params.idx);

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
        [JsonPropertyName("idx")]
        public int idx { get; set; }
    }
}
