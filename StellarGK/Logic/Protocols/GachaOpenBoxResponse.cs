using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class GachaOpenBoxResponse
    {
        [JsonPropertyName("gbIdx")]
        public EGachaAnimationType type { get; set; }

        [JsonPropertyName("gacha")]
        public List<Reward> rewardList { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource goodsResult { get; set; }

        [JsonPropertyName("commMedl")]
        public Dictionary<string, CommanderMedal> commanderIdMedalDict { get; set; }

        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderIdDict { get; set; }

        [JsonPropertyName("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }

        [JsonPropertyName("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonPropertyName("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonPropertyName("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonPropertyName("info")]
        public GachaInformationResponse changedGachaInformation { get; set; }

        [JsonPropertyName("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonPropertyName("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }


        public class Reward
        {
            [JsonPropertyName("type")]
            public ERewardType type { get; set; }

            [JsonPropertyName("idx")]
            public string id { get; set; }

            [JsonPropertyName("cnt")]
            public int count { get; set; }
        }


        public class CommanderMedal
        {
            [JsonPropertyName("medl")]
            public int medal { get; set; }
        }
    }
}
