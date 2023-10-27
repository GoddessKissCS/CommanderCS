using Newtonsoft.Json;
using StellarGKLibrary.Enum;

namespace StellarGKLibrary.Protocols
{

    public class RewardInfo
    {
        [JsonProperty("reward")]
        public List<RewardData> reward { get; set; }

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
        public List<Dictionary<string, HaveCostumeInfo>> costumeData { get; set; }

        [JsonProperty("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonProperty("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonProperty("achv")]
        public AchievementData nextAchievement { get; set; }

        [JsonProperty("uinfo")]
        public UserInformationResponse.BattleStatistics userInfo { get; set; }

        [JsonProperty("achvs")]
        public List<AchievementData> nextAchievementList { get; set; }

        [JsonProperty("comp")]
        public List<int> receiveMissinIdx { get; set; }

        [JsonProperty("compa")]
        public Dictionary<string, int> receiveAchievementIdx { get; set; }

        [JsonProperty("drsoc")]
        public Dormitory.Resource dormitoryResource { get; set; }

        [JsonProperty("deco")]
        public Dictionary<string, int> dormitoryItemNormal { get; set; }

        [JsonProperty("sdeco")]
        public Dictionary<string, int> dormitoryItemAdvanced { get; set; }

        [JsonProperty("wall")]
        public Dictionary<string, int> dormitoryItemWallpaper { get; set; }

        [JsonProperty("bcos")]
        public Dictionary<string, int> dormitoryCostumeBody { get; set; }

        [JsonProperty("hcos")]
        public Dictionary<string, List<string>> dormitoryCostumeHead { get; set; }

        [JsonProperty("weapon")]
        public Dictionary<string, WeaponData> weaponList { get; set; }

        [JsonProperty("gts")]
        public int time { get; set; }

        [JsonProperty("prc")]
        public float inAppPrice { get; set; }

        [JsonProperty("exp")]
        public int exp { get; set; }

        [JsonProperty("exps")]
        public List<ExplorationExp> explorationExp { get; set; }


        public class RewardData
        {
            [JsonProperty("rwdType")]
            public ERewardType rewardType { get; set; }

            [JsonProperty("rwdIdx")]
            public string rewardId { get; set; }

            [JsonProperty("cnt")]
            public int rewardCnt { get; set; }

            [JsonProperty("efct")]
            public int effect { get; set; }
        }


        public class CommanderMedal
        {
            [JsonProperty("medl")]
            public int medal { get; set; }
        }


        public class AchievementData
        {
            [JsonProperty("acid")]
            public int achievementId { get; set; }

            [JsonProperty("asot")]
            public int sort { get; set; }

            [JsonProperty("apt")]
            public int point { get; set; }

            [JsonProperty("fin")]
            public int complete { get; set; }

            [JsonProperty("arcv")]
            public int receive { get; set; }
        }


        public class HaveCostumeInfo
        {
            [JsonProperty("clst")]
            public List<int> haveCostume { get; set; }
        }


        public class ExplorationExp
        {
            [JsonProperty("idx")]
            public int idx { get; set; }

            [JsonProperty("exp")]
            public int exp { get; set; }
        }
    }
}
