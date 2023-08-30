using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Protocols
{

    public class CashShopData
    {
        [JsonProperty("ptyp")]
        public ECashRechargePriceType pType { get; set; }

        [JsonProperty("prc")]
        public string price { get; set; }

        [JsonProperty("prId")]
        public string priceId { get; set; }

        [JsonProperty("evcs")]
        public int eventCash { get; set; }

        [JsonProperty("fscs")]
        public int firstBuyCash { get; set; }

        [JsonProperty("remain")]
        public double remainTime { get; set; }

        [JsonProperty("cnt")]
        public int buyCount { get; set; }
    }

}
