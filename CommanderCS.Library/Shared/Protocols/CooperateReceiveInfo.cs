using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class CooperateReceiveInfo
    {
        [JsonProperty("stage")]
        public int stage { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }
    }
}