using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class WorldMapEndProductionResponse
    {
        [JsonProperty("res")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("reward")]
        public List<RewardInfo.RewardData> reward { get; set; }

        [JsonProperty("pldr")]
        public bool plundered { get; set; }
    }
}