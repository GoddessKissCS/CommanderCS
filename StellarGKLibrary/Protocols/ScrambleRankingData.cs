using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class ScrambleRankingData
    {
        [JsonProperty("score")]
        public int score { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("thmb")]
        public string thmb { get; set; }

        [JsonProperty("lv")]
        public int lv { get; set; }

        [JsonProperty("role")]
        public int role { get; set; }
    }
}