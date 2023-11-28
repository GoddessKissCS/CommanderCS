using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class ScrambleMapHistory
    {
        [JsonProperty("result")]
        public int result { get; set; }

        [JsonProperty("my")]
        public userData myHistory { get; set; }

        [JsonProperty("enmy")]
        public userData enemyHistory { get; set; }

        public class userData
        {
            [JsonProperty("dnm")]
            public string troopName { get; set; }

            [JsonProperty("pwr")]
            public int power { get; set; }

            [JsonProperty("cid")]
            public string cid { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("grd")]
            public int grade { get; set; }

            [JsonProperty("cls")]
            public int cls { get; set; }

            [JsonProperty("cos")]
            public int costume { get; set; }

            [JsonProperty("rsf")]
            public int favorRewardStep { get; set; }

            [JsonProperty("mry")]
            public int marry { get; set; }

            [JsonProperty("tsdc")]
            public List<int> transcendence { get; set; }

            [JsonProperty("nm")]
            public string nickName { get; set; }

            [JsonProperty("uLv")]
            public int userLevel { get; set; }

            [JsonProperty("deck")]
            public object __troopSlotsSource { get; set; }
        }

        public class Slot
        {
            [JsonProperty("uid")]
            public string unitId { get; set; }

            [JsonProperty("hpPercent")]
            public int unitHp { get; set; }

            [JsonProperty("lev")]
            public int unitLevel { get; set; }
        }
    }
}