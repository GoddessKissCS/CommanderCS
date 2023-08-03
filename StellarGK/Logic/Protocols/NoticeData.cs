using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class NoticeData
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

        [JsonPropertyName("img")]
        public string img { get; set; }

        [JsonPropertyName("ctnt")]
        public string notice { get; set; }

        [JsonPropertyName("link")]
        public string link { get; set; }

        [JsonPropertyName("sdt")]
        public double startDate { get; set; }

        [JsonPropertyName("edt")]
        public double endDate { get; set; }

        [JsonPropertyName("esdt")]
        public double eventStartDate { get; set; }

        [JsonPropertyName("eedt")]
        public double eventEndDate { get; set; }

        [JsonPropertyName("fixed")]
        public int notiFixed { get; set; }
    }
}
