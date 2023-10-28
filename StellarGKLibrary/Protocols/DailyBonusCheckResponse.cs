using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class DailyBonusCheckResponse
    {
        [JsonProperty("ver")]
        public string version { get; set; }

        [JsonProperty("didx")]
        public int day { get; set; }

        [JsonProperty("gidx")]
        public string goodsId { get; set; }

        [JsonProperty("amnt")]
        public int goodsCount { get; set; }

        [JsonProperty("sdt")]
        public string startTimeString { get; set; }

        [JsonProperty("edt")]
        public string endTimeString { get; set; }

        [JsonProperty("rcvd")]
        public int receiveState { get; set; }
    }
}