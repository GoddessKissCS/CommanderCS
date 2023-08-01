using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
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

        public bool received
        {
            get
            {
                return receiveState > 0;
            }
        }
    }
}
