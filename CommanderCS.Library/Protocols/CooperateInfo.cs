using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class CooperateInfo
    {
        [JsonProperty("stage")]
        public int stage { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }

        [JsonProperty("remain")]
        public int remain { get; set; }

        [JsonProperty("dmg")]
        public ulong dmg { get; set; }

        [JsonProperty("ticket")]
        public int ticket { get; set; }
    }
}