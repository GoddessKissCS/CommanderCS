using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BankInfo
    {
        [JsonProperty("chip")]
        public string __chip { get; set; }

        [JsonProperty("lev")]
        public int level { get; set; }

        [JsonProperty("luck")]
        public int luck { get; set; }

        [JsonProperty("rfcnt")]
        public int exchangeRateCnt { get; set; }

        [JsonProperty("remain")]
        public int remain { get; set; }

        [JsonProperty("cash")]
        public string __cash { get; set; }
    }
}
