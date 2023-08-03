using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EventRaidList
    {
        [JsonPropertyName("rcnt")]
        public int rewardCount { get; set; }

        [JsonPropertyName("list")]
        public List<EventRaidData> bossList { get; set; }
    }
}
