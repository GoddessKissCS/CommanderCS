using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MoveConquestTroop
    {
        [JsonProperty("path")]
        public List<int> path { get; set; }

        [JsonProperty("distance")]
        public int distance { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }

        [JsonProperty("ucash")]
        public int ucash { get; set; }
    }
}
