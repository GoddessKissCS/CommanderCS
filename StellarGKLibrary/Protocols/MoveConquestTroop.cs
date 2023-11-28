using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
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