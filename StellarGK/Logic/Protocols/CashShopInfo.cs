using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CashShopInfo
    {
        [JsonPropertyName("cstp")]
        public int cashType { get; set; }

        [JsonPropertyName("csam")]
        public int cashAmount { get; set; }

        [JsonPropertyName("gmcs")]
        public int gameCash { get; set; }

        [JsonPropertyName("csevt")]
        public int eventCashAmount { get; set; }

        [JsonPropertyName("gmcsevt")]
        public int eventGameCash { get; set; }

        [JsonPropertyName("evtId")]
        public int eventId { get; set; }
    }
}
