using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RewardInfo
    {
        [JsonPropertyName("reward")]
        public List<RewardData> reward { get; set; }

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
        public List<Dictionary<string, HaveCostumeInfo>> costumeData { get; set; }

        [JsonPropertyName("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonPropertyName("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonPropertyName("achv")]
        public AchievementData nextAchievement { get; set; }

        [JsonPropertyName("uinfo")]
        public UserInformationResponse.BattleStatistics userInfo { get; set; }

        [JsonPropertyName("achvs")]
        public List<AchievementData> nextAchievementList { get; set; }

        [JsonPropertyName("comp")]
        public List<int> receiveMissinIdx { get; set; }

        [JsonPropertyName("compa")]
        public Dictionary<string, int> receiveAchievementIdx { get; set; }

        [JsonPropertyName("drsoc")]
        public Dormitory.Resource dormitoryResource { get; set; }

        [JsonPropertyName("deco")]
        public Dictionary<string, int> dormitoryItemNormal { get; set; }

        [JsonPropertyName("sdeco")]
        public Dictionary<string, int> dormitoryItemAdvanced { get; set; }

        [JsonPropertyName("wall")]
        public Dictionary<string, int> dormitoryItemWallpaper { get; set; }

        [JsonPropertyName("bcos")]
        public Dictionary<string, int> dormitoryCostumeBody { get; set; }

        [JsonPropertyName("hcos")]
        public Dictionary<string, List<string>> dormitoryCostumeHead { get; set; }

        [JsonPropertyName("weapon")]
        public Dictionary<string, WeaponData> weaponList { get; set; }

        [JsonPropertyName("gts")]
        public int time { get; set; }

        [JsonPropertyName("prc")]
        public float inAppPrice { get; set; }

        [JsonPropertyName("exp")]
        public int exp { get; set; }

        [JsonPropertyName("exps")]
        public List<ExplorationExp> explorationExp { get; set; }


        public class RewardData
        {
            [JsonPropertyName("rwdType")]
            public ERewardType rewardType { get; set; }

            [JsonPropertyName("rwdIdx")]
            public string rewardId { get; set; }

            [JsonPropertyName("cnt")]
            public int rewardCnt { get; set; }

            [JsonPropertyName("efct")]
            public int effect { get; set; }
        }


        public class CommanderMedal
        {
            [JsonPropertyName("medl")]
            public int medal { get; set; }
        }


        public class AchievementData
        {
            [JsonPropertyName("acid")]
            public int achievementId { get; set; }

            [JsonPropertyName("asot")]
            public int sort { get; set; }

            [JsonPropertyName("apt")]
            public int point { get; set; }

            [JsonPropertyName("fin")]
            public int complete { get; set; }

            [JsonPropertyName("arcv")]
            public int receive { get; set; }
        }


        public class HaveCostumeInfo
        {
            [JsonPropertyName("clst")]
            public List<int> haveCostume { get; set; }
        }


        public class ExplorationExp
        {
            [JsonPropertyName("idx")]
            public int idx { get; set; }

            [JsonPropertyName("exp")]
            public int exp { get; set; }
        }
    }
}
