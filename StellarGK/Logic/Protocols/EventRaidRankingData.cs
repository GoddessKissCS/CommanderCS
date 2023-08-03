using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EventRaidRankingData
    {
        [JsonPropertyName("uname")]
        public string userName { get; set; }

        [JsonPropertyName("thumb")]
        public string userThumb { get; set; }

        [JsonPropertyName("level")]
        public string level { get; set; }

        [JsonPropertyName("accdmg")]
        public int damage { get; set; }

        [JsonPropertyName("authority")]
        public int authority { get; set; }

        [JsonPropertyName("isown")]
        public int isown { get; set; }
    }
}
