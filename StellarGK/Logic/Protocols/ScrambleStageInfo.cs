using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace StellarGK.Logic.Protocols
{

    public class ScrambleStageInfo
    {
        [JsonPropertyName("myDeck")]
        public Dictionary<string, UserInformationResponse.Unit> myDeck { get; set; }

        [JsonPropertyName("enemy")]
        public EnemyCommander enemy { get; set; }

        [JsonPropertyName("stageInfo")]
        public UserInfo user { get; set; }


        public class UserInfo
        {
            [JsonPropertyName("unm")]
            public string name { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("thmb")]
            public int thumb { get; set; }
        }


        public class EnemyCommander
        {
            [JsonPropertyName("uno")]
            public string uno { get; set; }

            [JsonPropertyName("cid")]
            public string id { get; set; }

            [JsonPropertyName("lv")]
            public string __level { get; set; }

            [JsonPropertyName("grd")]
            public string __rank { get; set; }

            [JsonPropertyName("cls")]
            public string __cls { get; set; }

            [JsonPropertyName("skv1")]
            public string __skv1 { get; set; }

            [JsonPropertyName("skv2")]
            public string __skv2 { get; set; }

            [JsonPropertyName("skv3")]
            public string __skv3 { get; set; }

            [JsonPropertyName("skv4")]
            public string __skv4 { get; set; }

            [JsonPropertyName("pwr")]
            public int power { get; set; }

            [JsonPropertyName("dnm")]
            public string troopNickname { get; set; }

            [JsonPropertyName("uLv")]
            public string userLevel { get; set; }

            [JsonPropertyName("nm")]
            public string nickname { get; set; }

            [JsonPropertyName("thumb")]
            public int thumbnail { get; set; }

            [JsonPropertyName("deck")]
            public object __troopSlotsSource { get; set; }

            [JsonPropertyName("gsk")]
            public List<GuildSkill> guildSkillList { get; set; }

            public Dictionary<int, Slot> troopSlots
            {
                get
                {
                    if (__troopSlotsSource == null)
                    {
                        return null;
                    }
                    JArray jarray = null;
                    try
                    {
                        jarray = JArray.FromObject(__troopSlotsSource);
                    }
                    catch (Exception ex)
                    {
                        _ = ex;
                    }
                    if (jarray != null)
                    {
                        return null;
                    }
                    JObject jobject = JObject.FromObject(__troopSlotsSource);
                    return jobject.ToObject<Dictionary<int, Slot>>();
                }
            }


            public class Slot
            {
                [JsonPropertyName("uid")]
                public string unitId { get; set; }

                [JsonPropertyName("hp")]
                public int unitHp { get; set; }

                [JsonPropertyName("lv")]
                public int unitLevel { get; set; }
            }


            public class GuildSkill
            {
                [JsonPropertyName("GS_Idx")]
                public string idx { get; set; }

                [JsonPropertyName("GS_Level")]
                public int level { get; set; }
            }
        }
    }
}
