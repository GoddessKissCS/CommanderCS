using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EventBattleGachaOpen
    {
        [JsonPropertyName("reward")]
        public List<RewardInfo.RewardData> rewardList { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonPropertyName("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonPropertyName("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonPropertyName("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonPropertyName("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }

        [JsonPropertyName("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonPropertyName("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonPropertyName("season")]
        public int season { get; set; }

        [JsonPropertyName("reset")]
        public int reset { get; set; }

        [JsonPropertyName("info")]
        public Dictionary<int, int> info { get; set; }
    }
}
