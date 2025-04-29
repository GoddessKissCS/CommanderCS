using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class WorldDuelInformation
    {
        [JsonProperty("itrm")]
        public double resetTime { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("deck")]
        public Dictionary<string, string> deck { get; set; }

        [JsonProperty("buff")]
        public Dictionary<string, int> duelBuff { get; set; }

        [JsonProperty("bbf")]
        public List<int> activeBuff { get; set; }

        [JsonProperty("rank")]
        public RankingUserData user { get; set; }

        [JsonProperty("trank")]
        public List<PvPRankingList.RankData> rankingList { get; set; }

        [JsonProperty("open")]
        public string _open { get; set; }

        [JsonProperty("lsinfo")]
        public UserData bestRank { get; set; }

        [JsonProperty("retryinfo")]
        public PvPDuelList.PvPDuelData retryInfo { get; set; }

        public class UserData
        {
            [JsonProperty("wld")]
            public int world { get; set; }

            [JsonProperty("unm")]
            public string userName { get; set; }

            [JsonProperty("gld")]
            public string guildName { get; set; }

            [JsonProperty("gwld")]
            public int guildWorld { get; set; }

            [JsonProperty("score")]
            public int score { get; set; }

            [JsonProperty("win")]
            public int win { get; set; }

            [JsonProperty("lose")]
            public int lose { get; set; }

            [JsonProperty("thmb")]
            public string thmb { get; set; }
        }
    }
}