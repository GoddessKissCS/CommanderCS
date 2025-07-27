using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class SituationExploreReward
    {
        [JsonProperty("sply")]
        public int exploreTicket { get; set; }

        [JsonProperty("gold")]
        public string __gold { get; set; }

        [JsonProperty("cash")]
        public string __cash { get; set; }

        [JsonProperty("reward")]
        public object __reward { get; set; }
    }
}