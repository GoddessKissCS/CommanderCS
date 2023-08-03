using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class WorldMapEndProductionResponse
    {
        [JsonPropertyName("res")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("reward")]
        public List<RewardInfo.RewardData> reward { get; set; }

        [JsonPropertyName("pldr")]
        public bool plundered { get; set; }
    }
}
