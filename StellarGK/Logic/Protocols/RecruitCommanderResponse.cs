using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class RecruitCommanderResponse
    {
        [JsonPropertyName("gold")]
        public long gold { get; set; }

        [JsonPropertyName("honr")]
        public int honor { get; set; }

        [JsonPropertyName("medl")]
        public int medal { get; set; }

        [JsonPropertyName("comm")]
        public SimpleCommanderInfo commander { get; set; }
    }
}
