using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class AnnihilationMapInfo
    {
        [JsonPropertyName("mst")]
        public int stage { get; set; }

        [JsonPropertyName("adpt")]
        public int isPlayAdvanceParty { get; set; }

        [JsonPropertyName("lcid")]
        public List<string> dieCommanderList { get; set; }

        [JsonPropertyName("clear")]
        public int clear { get; set; }

        [JsonPropertyName("remain")]
        public int remainTime { get; set; }

        [JsonPropertyName("vcid")]
        public List<StatusData> commanderStatusList { get; set; }

        [JsonPropertyName("enemy")]
        public List<Dictionary<int, CommanderData>> enemyList { get; set; }

        [JsonPropertyName("rInfo")]
        public object __advancePartyReward { get; set; }

        [JsonPropertyName("mode")]
        public AnnihilationMode mode { get; set; }
        public class CommanderData
        {
            [JsonPropertyName("uid")]
            public string id { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("spd")]
            public int speed { get; set; }

            [JsonPropertyName("hp")]
            public int hp { get; set; }
        }
        public class AdvancePartyRewardInfo
        {
            [JsonPropertyName("reward")]
            public List<List<RewardInfo.RewardData>> rewardList { get; set; }

            [JsonPropertyName("rsoc")]
            public UserInformationResponse.Resource resource { get; set; }

            [JsonPropertyName("part")]
            public Dictionary<string, int> partData { get; set; }

            [JsonPropertyName("medl")]
            public Dictionary<string, int> medalData { get; set; }

            [JsonPropertyName("ersoc")]
            public Dictionary<string, int> eventResourceData { get; set; }

            [JsonPropertyName("item")]
            public Dictionary<string, int> itemData { get; set; }
        }
        public class StatusData
        {
            [JsonPropertyName("cid")]
            public string id { get; set; }

            [JsonPropertyName("dmghp")]
            public string __dmghp { get; set; }

            [JsonPropertyName("sp")]
            public int sp { get; set; }
        }
    }
}
