using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class InfinityTowerReward : RewardInfo
    {
        [JsonProperty("tinfo")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}