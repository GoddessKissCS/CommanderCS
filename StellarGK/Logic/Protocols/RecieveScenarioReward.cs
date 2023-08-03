using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RecieveScenarioReward
    {
        [JsonPropertyName("reward")]
        public List<RewardInfo.RewardData> reward { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commander { get; set; }

        [JsonPropertyName("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonPropertyName("rank")]
        public Dictionary<string, int> duelScoreData { get; set; }

        [JsonPropertyName("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonPropertyName("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonPropertyName("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonPropertyName("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }
    }
}
