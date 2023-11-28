using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class CooperateReceiveInfo
    {
        [JsonProperty("stage")]
        public int stage { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }
    }
}