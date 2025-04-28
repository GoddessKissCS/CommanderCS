using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class EventBattleInfo
    {
        [JsonProperty("eidx")]
        public string idx { get; set; }

        [JsonProperty("remain")]
        public double remain { get; set; }

        [JsonProperty("rcnt")]
        public int rewardCount { get; set; }
    }
}