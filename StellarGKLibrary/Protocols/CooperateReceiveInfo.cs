using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class CooperateReceiveInfo
    {
        [JsonProperty("stage")]
        public int stage { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }
    }
}
