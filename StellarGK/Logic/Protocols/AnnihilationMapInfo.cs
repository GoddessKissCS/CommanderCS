using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using StellarGK.Logic.Enums;

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

        public AdvancePartyRewardInfo advancePartyReward
        {
            get
            {
                if (__advancePartyReward == null)
                {
                    return null;
                }
                JArray jarray = null;
                try
                {
                    jarray = JArray.FromObject(__advancePartyReward);
                }
                catch (Exception ex)
                {
                    _ = ex;
                }
                if (jarray != null)
                {
                    return null;
                }
                JObject jobject = JObject.FromObject(__advancePartyReward);
                return jobject.ToObject<AdvancePartyRewardInfo>();
            }
        }

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
