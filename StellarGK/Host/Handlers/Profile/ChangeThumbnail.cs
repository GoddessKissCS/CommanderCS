using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Command(Id = CommandId.ChangeUserThumbnail)]
    public class ChangeThumbnail : BaseCommandHandler<ChangeThumbnailRequest>
    {
        public override string Handle(ChangeThumbnailRequest @params)
        {
            ResponsePacket response = new();

            // TODO - MISSING FALSE HANDLING

            bool success = DatabaseManager.Resources.ChangeThumbnail(@params.idx, BasePacket.Session);

            response.id = BasePacket.Id;

            if (success)
            {
                response.result = "true";

                return JsonConvert.SerializeObject(response);
            }
            else
            {
                response.result = "false";

                return JsonConvert.SerializeObject(response);
            }
        }

    }
    public class ChangeThumbnailRequest
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

    }
}
