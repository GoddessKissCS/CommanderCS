using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class RecallCommander
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("rgtm")]
        public int runtime { get; set; }

        [JsonProperty("egld")]
        public int getGold_time { get; set; }

        [JsonProperty("exgd")]
        public int getGold_engage { get; set; }
    }
}