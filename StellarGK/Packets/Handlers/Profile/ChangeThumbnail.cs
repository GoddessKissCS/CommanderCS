using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Command(Id = CommandId.ChangeUserThumbnail)]
    public class ChangeThumbnail : BaseCommandHandler<ChangeThumbnailRequest>
    {
        public override object Handle(ChangeThumbnailRequest @params)
        {
            ResponsePacket response = new();

            // TODO - MISSING FALSE HANDLING

            bool success = DatabaseManager.GameProfile.ChangeThumbnail(GetSession(), @params.idx);

            response.id = BasePacket.Id;

            if (success)
            {
                response.result = "true";

                return response;
            }
            else
            {
                response.result = "false";

                return response;
            }
        }

    }
    public class ChangeThumbnailRequest
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

    }
}
