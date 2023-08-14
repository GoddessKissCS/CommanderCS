using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Command(Id = CommandId.ChangeUserThumbnail)]
    public class ChangeThumbnail : BaseCommandHandler<ChangeThumbnailRequest>
    {
        public override object Handle(ChangeThumbnailRequest @params)
        {

            // TODO - MISSING FALSE HANDLING

            bool success = DatabaseManager.GameProfile.ChangeThumbnail(GetSession(), @params.idx);

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = success.ToString()
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
