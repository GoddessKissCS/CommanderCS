using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class PvPDuelList
    {
        [JsonProperty("rfrm")]
        public int remain { get; set; }

        [JsonProperty("itrm")]
        public int time { get; set; }

        [JsonProperty("oprm")]
        public int openRemain { get; set; }

        [JsonProperty("user")]
        public RankingUserData user { get; set; }

        [JsonProperty("list")]
        public Dictionary<int, PvPDuelData> duelList { get; set; }

        public class PvPDuelData
        {
            [JsonProperty("uno")]
            public int uno { get; set; }

            [JsonProperty("idx")]
            public int idx { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("unm")]
            public string _name { get; set; }

            [JsonProperty("rank")]
            public int rank { get; set; }

            [JsonProperty("clr")]
            public string clear { get; set; }

            [JsonProperty("thmb")]
            public string thumbnail { get; set; }

            [JsonProperty("deck")]
            public List<PvPDuelDeck> deck { get; set; }

            [JsonProperty("decks")]
            public Dictionary<string, List<PvPDuelDeck>> decks { get; set; }

            [JsonProperty("gnm", NullValueHandling = NullValueHandling.Ignore)]
            public string guildName { get; set; }

            [JsonProperty("gld")]
            public List<GuildSkill> guildSkills { get; set; }

            [JsonProperty("grp")]
            public List<int> groupBuffs { get; set; }

            [JsonProperty("wld")]
            public int world { get; set; }

            [JsonProperty("buff")]
            public Dictionary<string, int> duelBuff { get; set; }

            [JsonProperty("bbf")]
            public List<int> activeBuff { get; set; }

            [JsonProperty("wrank")]
            public int winRank { get; set; }

            [JsonProperty("wridx")]
            public int winRankIdx { get; set; }

            [JsonProperty("score")]
            public int score { get; set; }

            [JsonProperty("win")]
            public int winCnt { get; set; }

            [JsonProperty("lose")]
            public int loseCnt { get; set; }
        }

        public class GuildSkill
        {
            [JsonProperty("gsid")]
            public int idx { get; set; }

            [JsonProperty("gslv")]
            public int level { get; set; }
        }

        public class PvPDuelDeck
        {
            [JsonProperty("pos")]
            public int position { get; set; }

            [JsonProperty("cid")]
            public int commanderId { get; set; }

            [JsonProperty("grd")]
            public int grade { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

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

            [JsonProperty("skil1")]
            public int skill1 { get; set; }

            [JsonProperty("skil2")]
            public int skill2 { get; set; }

            [JsonProperty("skil3")]
            public int skill3 { get; set; }

            [JsonProperty("skil4")]
            public int skill4 { get; set; }

            [JsonProperty("equip")]
            public Dictionary<string, int> equipItem { get; set; }

            [JsonProperty("wp")]
            public Dictionary<string, WeaponData> weaponItem { get; set; }
        }
    }
}