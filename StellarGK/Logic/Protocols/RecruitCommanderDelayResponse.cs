using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RecruitCommanderDelayResponse
    {
        [JsonPropertyName("wait")]
        public int wait { get; set; }

        [JsonPropertyName("gold")]
        public string __gold { get; set; }

        [JsonPropertyName("cash")]
        public string __cash { get; set; }

        [JsonPropertyName("comm")]
        public SimpleCommanderInfo commander { get; set; }
    }
}
