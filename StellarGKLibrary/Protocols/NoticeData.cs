using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class NoticeData
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("img")]
        public string img { get; set; }

        [JsonProperty("ctnt")]
        public string notice { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("sdt")]
        public double startDate { get; set; }

        [JsonProperty("edt")]
        public double endDate { get; set; }

        [JsonProperty("esdt")]
        public double eventStartDate { get; set; }

        [JsonProperty("eedt")]
        public double eventEndDate { get; set; }

        [JsonProperty("fixed")]
        public int notiFixed { get; set; }
    }
}
