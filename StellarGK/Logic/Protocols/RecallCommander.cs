using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RecallCommander
    {
        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("rgtm")]
        public int runtime { get; set; }

        [JsonPropertyName("egld")]
        public int getGold_time { get; set; }

        [JsonPropertyName("exgd")]
        public int getGold_engage { get; set; }
    }
}
