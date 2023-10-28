using Newtonsoft.Json;
using StellarGKLibrary.Enum;

namespace StellarGKLibrary.Protocols
{
    public class GachaOpenBoxResponse
    {
        [JsonProperty("gbIdx")]
        public EGachaAnimationType type { get; set; }

        [JsonProperty("gacha")]
        public List<Reward> rewardList { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource goodsResult { get; set; }

        [JsonProperty("commMedl")]
        public Dictionary<string, CommanderMedal> commanderIdMedalDict { get; set; }

        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderIdDict { get; set; }

        [JsonProperty("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }

        [JsonProperty("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonProperty("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonProperty("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonProperty("info")]
        public GachaInformationResponse changedGachaInformation { get; set; }

        [JsonProperty("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonProperty("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        public class Reward
        {
            [JsonProperty("type")]
            public ERewardType type { get; set; }

            [JsonProperty("idx")]
            public string id { get; set; }

            [JsonProperty("cnt")]
            public int count { get; set; }
        }

        public class CommanderMedal
        {
            [JsonProperty("medl")]
            public int medal { get; set; }
        }
    }
}