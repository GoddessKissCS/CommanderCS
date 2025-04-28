using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class InfinityTowerReward : RewardInfo
    {
        [JsonProperty("tinfo")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}