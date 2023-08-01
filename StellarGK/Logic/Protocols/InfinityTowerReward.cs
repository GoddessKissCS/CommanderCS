using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class InfinityTowerReward : RewardInfo
    {
        [JsonProperty("tinfo")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}
