using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class EventRaidList
    {
        [JsonProperty("rcnt")]
        public int rewardCount { get; set; }

        [JsonProperty("list")]
        public List<EventRaidData> bossList { get; set; }
    }
}