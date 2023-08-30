using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Protocols
{

    public class AnnihilationMapInfo
    {
        [JsonProperty("mst")]
        public int stage { get; set; }

        [JsonProperty("adpt")]
        public int isPlayAdvanceParty { get; set; }

        [JsonProperty("lcid")]
        public List<string> dieCommanderList { get; set; }

        [JsonProperty("clear")]
        public int clear { get; set; }

        [JsonProperty("remain")]
        public int remainTime { get; set; }

        [JsonProperty("vcid")]
        public List<StatusData> commanderStatusList { get; set; }

        [JsonProperty("enemy")]
        public List<Dictionary<int, CommanderData>> enemyList { get; set; }

        [JsonProperty("rInfo")]
        public object __advancePartyReward { get; set; }

        [JsonProperty("mode")]
        public AnnihilationMode mode { get; set; }
        public class CommanderData
        {
            [JsonProperty("uid")]
            public string id { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("spd")]
            public int speed { get; set; }

            [JsonProperty("hp")]
            public int hp { get; set; }
        }
        public class AdvancePartyRewardInfo
        {
            [JsonProperty("reward")]
            public List<List<RewardInfo.RewardData>> rewardList { get; set; }

            [JsonProperty("rsoc")]
            public UserInformationResponse.Resource resource { get; set; }

            [JsonProperty("part")]
            public Dictionary<string, int> partData { get; set; }

            [JsonProperty("medl")]
            public Dictionary<string, int> medalData { get; set; }

            [JsonProperty("ersoc")]
            public Dictionary<string, int> eventResourceData { get; set; }

            [JsonProperty("item")]
            public Dictionary<string, int> itemData { get; set; }
        }
        public class StatusData
        {
            [JsonProperty("cid")]
            public string id { get; set; }

            [JsonProperty("dmghp")]
            public string __dmghp { get; set; }

            [JsonProperty("sp")]
            public int sp { get; set; }
        }
    }
}
