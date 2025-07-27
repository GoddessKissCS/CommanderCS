using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class RecruitCommanderResponse
    {
        [JsonProperty("gold")]
        public long gold { get; set; }

        [JsonProperty("honr")]
        public int honor { get; set; }

        [JsonProperty("medl")]
        public int medal { get; set; }

        [JsonProperty("comm")]
        public SimpleCommanderInfo commander { get; set; }
    }
}