using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class PvPDuelList
    {
        [JsonPropertyName("rfrm")]
        public int remain { get; set; }

        [JsonPropertyName("itrm")]
        public int time { get; set; }

        [JsonPropertyName("oprm")]
        public int openRemain { get; set; }

        [JsonPropertyName("user")]
        public RankingUserData user { get; set; }

        [JsonPropertyName("list")]
        public Dictionary<int, PvPDuelData> duelList { get; set; }


        public class PvPDuelData
        {
            [JsonPropertyName("uno")]
            public int uno { get; set; }

            [JsonPropertyName("idx")]
            public int idx { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("unm")]
            public string _name { get; set; }

            [JsonPropertyName("rank")]
            public int rank { get; set; }

            [JsonPropertyName("clr")]
            public string clear { get; set; }

            [JsonPropertyName("thmb")]
            public string thumbnail { get; set; }

            [JsonPropertyName("deck")]
            public List<PvPDuelDeck> deck { get; set; }

            [JsonPropertyName("decks")]
            public Dictionary<string, List<PvPDuelDeck>> decks { get; set; }

            [JsonPropertyName("gnm")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string guildName { get; set; }

            [JsonPropertyName("gld")]
            public List<GuildSkill> guildSkills { get; set; }

            [JsonPropertyName("grp")]
            public List<int> groupBuffs { get; set; }

            [JsonPropertyName("wld")]
            public int world { get; set; }

            [JsonPropertyName("buff")]
            public Dictionary<string, int> duelBuff { get; set; }

            [JsonPropertyName("bbf")]
            public List<int> activeBuff { get; set; }

            [JsonPropertyName("wrank")]
            public int winRank { get; set; }

            [JsonPropertyName("wridx")]
            public int winRankIdx { get; set; }

            [JsonPropertyName("score")]
            public int score { get; set; }

            [JsonPropertyName("win")]
            public int winCnt { get; set; }

            [JsonPropertyName("lose")]
            public int loseCnt { get; set; }

        }


        public class GuildSkill
        {
            [JsonPropertyName("gsid")]
            public int idx { get; set; }

            [JsonPropertyName("gslv")]
            public int level { get; set; }
        }


        public class PvPDuelDeck
        {
            [JsonPropertyName("pos")]
            public int position { get; set; }

            [JsonPropertyName("cid")]
            public int commanderId { get; set; }

            [JsonPropertyName("grd")]
            public int grade { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

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

            [JsonPropertyName("skil1")]
            public int skill1 { get; set; }

            [JsonPropertyName("skil2")]
            public int skill2 { get; set; }

            [JsonPropertyName("skil3")]
            public int skill3 { get; set; }

            [JsonPropertyName("skil4")]
            public int skill4 { get; set; }

            [JsonPropertyName("equip")]
            public Dictionary<string, int> equipItem { get; set; }

            [JsonPropertyName("wp")]
            public Dictionary<string, WeaponData> weaponItem { get; set; }
        }
    }
}
