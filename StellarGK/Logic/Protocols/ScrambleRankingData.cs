using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ScrambleRankingData
    {
        [JsonPropertyName("score")]
        public int score { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("thmb")]
        public string thmb { get; set; }

        [JsonPropertyName("lv")]
        public int lv { get; set; }

        [JsonPropertyName("role")]
        public int role { get; set; }
    }
}
