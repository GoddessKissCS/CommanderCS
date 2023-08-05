using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ScrambleMapHistory
    {
        [JsonPropertyName("result")]
        public int result { get; set; }

        [JsonPropertyName("my")]
        public userData myHistory { get; set; }

        [JsonPropertyName("enmy")]
        public userData enemyHistory { get; set; }


        public class userData
        {
            [JsonPropertyName("dnm")]
            public string troopName { get; set; }

            [JsonPropertyName("pwr")]
            public int power { get; set; }

            [JsonPropertyName("cid")]
            public string cid { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("grd")]
            public int grade { get; set; }

            [JsonPropertyName("cls")]
            public int cls { get; set; }

            [JsonPropertyName("cos")]
            public int costume { get; set; }

            [JsonPropertyName("rsf")]
            public int favorRewardStep { get; set; }

            [JsonPropertyName("mry")]
            public int marry { get; set; }

            [JsonPropertyName("tsdc")]
            public List<int> transcendence { get; set; }

            [JsonPropertyName("nm")]
            public string nickName { get; set; }

            [JsonPropertyName("uLv")]
            public int userLevel { get; set; }

            [JsonPropertyName("deck")]
            public object __troopSlotsSource { get; set; }

        }


        public class Slot
        {
            [JsonPropertyName("uid")]
            public string unitId { get; set; }

            [JsonPropertyName("hpPercent")]
            public int unitHp { get; set; }

            [JsonPropertyName("lev")]
            public int unitLevel { get; set; }
        }
    }
}
