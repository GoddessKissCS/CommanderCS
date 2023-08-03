using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class InfinityTowerReward : RewardInfo
    {
        [JsonPropertyName("tinfo")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}
