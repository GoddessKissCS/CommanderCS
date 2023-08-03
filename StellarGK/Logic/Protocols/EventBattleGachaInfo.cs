using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EventBattleGachaInfo
    {
        [JsonPropertyName("season")]
        public int season { get; set; }

        [JsonPropertyName("reset")]
        public int reset { get; set; }

        [JsonPropertyName("info")]
        public Dictionary<int, int> info { get; set; }
    }
}
