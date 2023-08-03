using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class BankInfo
    {
        [JsonPropertyName("chip")]
        public string __chip { get; set; }

        [JsonPropertyName("lev")]
        public int level { get; set; }

        [JsonPropertyName("luck")]
        public int luck { get; set; }

        [JsonPropertyName("rfcnt")]
        public int exchangeRateCnt { get; set; }

        [JsonPropertyName("remain")]
        public int remain { get; set; }

        [JsonPropertyName("cash")]
        public string __cash { get; set; }
    }
}
