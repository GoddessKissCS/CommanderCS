using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class CompleteScenario
    {
        [JsonProperty("reward")]
        public List<RewardInfo.RewardData> reward { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commander { get; set; }

        [JsonProperty("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonProperty("rank")]
        public Dictionary<string, int> duelScoreData { get; set; }

        [JsonProperty("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonProperty("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonProperty("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonProperty("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }
    }
}