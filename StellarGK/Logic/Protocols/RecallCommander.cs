using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RecallCommander
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("rgtm")]
        public int runtime;

        [JsonProperty("egld")]
        public int getGold_time;

        [JsonProperty("exgd")]
        public int getGold_engage;
    }
}
