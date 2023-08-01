using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CooperateReceiveInfo
    {
        [JsonProperty("stage")]
        public int stage { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }
    }
}
