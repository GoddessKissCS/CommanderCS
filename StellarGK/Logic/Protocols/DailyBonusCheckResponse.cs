using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class DailyBonusCheckResponse
    {
        [JsonPropertyName("ver")]
        public string version { get; set; }

        [JsonPropertyName("didx")]
        public int day { get; set; }

        [JsonPropertyName("gidx")]
        public string goodsId { get; set; }

        [JsonPropertyName("amnt")]
        public int goodsCount { get; set; }

        [JsonPropertyName("sdt")]
        public string startTimeString { get; set; }

        [JsonPropertyName("edt")]
        public string endTimeString { get; set; }

        [JsonPropertyName("rcvd")]
        public int receiveState { get; set; }

        public bool received
        {
            get
            {
                return receiveState > 0;
            }
        }
    }
}
