using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class BuildingLevelUpResponse
    {
        [JsonPropertyName("gold")]
        public string __gold { get; set; }

        [JsonPropertyName("cash")]
        public string __cash { get; set; }

        [JsonPropertyName("remain")]
        public int remainTime { get; set; }
    }
}
