using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EventBattleInfo
    {
        [JsonPropertyName("eidx")]
        public string idx { get; set; }

        [JsonPropertyName("remain")]
        public double remain { get; set; }

        [JsonPropertyName("rcnt")]
        public int rewardCount { get; set; }
    }
}
