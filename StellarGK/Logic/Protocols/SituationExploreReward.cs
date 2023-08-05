using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class SituationExploreReward
    {
        [JsonPropertyName("sply")]
        public int exploreTicket { get; set; }

        [JsonPropertyName("gold")]
        public string __gold { get; set; }

        [JsonPropertyName("cash")]
        public string __cash { get; set; }

        [JsonPropertyName("reward")]
        public object __reward { get; set; }

    }
}
