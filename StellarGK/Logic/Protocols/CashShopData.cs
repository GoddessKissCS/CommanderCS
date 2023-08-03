using System.Text.Json.Serialization;
using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{

    public class CashShopData
    {
        [JsonPropertyName("ptyp")]
        public ECashRechargePriceType pType { get; set; }

        [JsonPropertyName("prc")]
        public string price { get; set; }

        [JsonPropertyName("prId")]
        public string priceId { get; set; }

        [JsonPropertyName("evcs")]
        public int eventCash { get; set; }

        [JsonPropertyName("fscs")]
        public int firstBuyCash { get; set; }

        [JsonPropertyName("remain")]
        public double remainTime { get; set; }

        [JsonPropertyName("cnt")]
        public int buyCount { get; set; }
    }

}
