using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class EventRaidRankingData
    {
        [JsonProperty("uname")]
        public string userName { get; set; }

        [JsonProperty("thumb")]
        public string userThumb { get; set; }

        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("accdmg")]
        public int damage { get; set; }

        [JsonProperty("authority")]
        public int authority { get; set; }

        [JsonProperty("isown")]
        public int isown { get; set; }
    }
}