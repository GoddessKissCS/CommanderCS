using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class CashShopInfo
    {
        [JsonProperty("cstp")]
        public int cashType { get; set; }

        [JsonProperty("csam")]
        public int cashAmount { get; set; }

        [JsonProperty("gmcs")]
        public int gameCash { get; set; }

        [JsonProperty("csevt")]
        public int eventCashAmount { get; set; }

        [JsonProperty("gmcsevt")]
        public int eventGameCash { get; set; }

        [JsonProperty("evtId")]
        public int eventId { get; set; }
    }
}