using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class EventRaidReward
    {
        [JsonProperty("reward")]
        public List<RewardInfo.RewardData> rewardList { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonProperty("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonProperty("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonProperty("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonProperty("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }

        [JsonProperty("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonProperty("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonProperty("rwdCnt")]
        public EventRaidRewardData rewardCount { get; set; }

        public class EventRaidRewardData
        {
            [JsonProperty("attend")]
            public int attend { get; set; }

            [JsonProperty("own")]
            public int own { get; set; }

            [JsonProperty("mvp")]
            public int mvp { get; set; }

            [JsonProperty("mbids")]
            public List<string> mbids { get; set; }
        }
    }
}