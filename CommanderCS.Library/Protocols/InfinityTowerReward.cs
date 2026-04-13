using CommanderCS.Library.Enums;
using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class InfinityTowerReward : RewardInfo
    {
        [JsonProperty("tinfo")]
        public Dictionary<string, Dictionary<int, EInfinityTowerStageState>> fieldData { get; set; }
    }
}