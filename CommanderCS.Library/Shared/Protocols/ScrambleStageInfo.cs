using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class ScrambleStageInfo
    {
        [JsonProperty("myDeck")]
        public Dictionary<string, UserInformationResponse.Unit> myDeck { get; set; }

        [JsonProperty("enemy")]
        public EnemyCommander enemy { get; set; }

        [JsonProperty("stageInfo")]
        public UserInfo user { get; set; }

        public class UserInfo
        {
            [JsonProperty("unm")]
            public string name { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("thmb")]
            public int thumb { get; set; }
        }

        public class EnemyCommander
        {
            [JsonProperty("uno")]
            public string uno { get; set; }

            [JsonProperty("cid")]
            public string id { get; set; }

            [JsonProperty("lv")]
            public string __level { get; set; }

            [JsonProperty("grd")]
            public string __rank { get; set; }

            [JsonProperty("cls")]
            public string __cls { get; set; }

            [JsonProperty("skv1")]
            public string __skv1 { get; set; }

            [JsonProperty("skv2")]
            public string __skv2 { get; set; }

            [JsonProperty("skv3")]
            public string __skv3 { get; set; }

            [JsonProperty("skv4")]
            public string __skv4 { get; set; }

            [JsonProperty("pwr")]
            public int power { get; set; }

            [JsonProperty("dnm")]
            public string troopNickname { get; set; }

            [JsonProperty("uLv")]
            public string userLevel { get; set; }

            [JsonProperty("nm")]
            public string nickname { get; set; }

            [JsonProperty("thumb")]
            public int thumbnail { get; set; }

            [JsonProperty("deck")]
            public object __troopSlotsSource { get; set; }

            [JsonProperty("gsk")]
            public List<GuildSkill> guildSkillList { get; set; }

            public class Slot
            {
                [JsonProperty("uid")]
                public string unitId { get; set; }

                [JsonProperty("hp")]
                public int unitHp { get; set; }

                [JsonProperty("lv")]
                public int unitLevel { get; set; }
            }

            public class GuildSkill
            {
                [JsonProperty("GS_Idx")]
                public string idx { get; set; }

                [JsonProperty("GS_Level")]
                public int level { get; set; }
            }
        }
    }
}