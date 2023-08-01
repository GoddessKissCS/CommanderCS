using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EventRaidList
    {
        [JsonProperty("rcnt")]
        public int rewardCount { get; set; }

        [JsonProperty("list")]
        public List<EventRaidData> bossList { get; set; }
    }
}
