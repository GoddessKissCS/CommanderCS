using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class WorldDuelInformation
    {
        [JsonPropertyName("itrm")]
        public double resetTime { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("deck")]
        public Dictionary<string, string> deck { get; set; }

        [JsonPropertyName("buff")]
        public Dictionary<string, int> duelBuff { get; set; }

        [JsonPropertyName("bbf")]
        public List<int> activeBuff { get; set; }

        [JsonPropertyName("rank")]
        public RankingUserData user { get; set; }

        [JsonPropertyName("trank")]
        public List<PvPRankingList.RankData> rankingList { get; set; }

        [JsonPropertyName("open")]
        public string _open { get; set; }

        [JsonPropertyName("lsinfo")]
        public UserData bestRank { get; set; }

        [JsonPropertyName("retryinfo")]
        public PvPDuelList.PvPDuelData retryInfo { get; set; }

        public bool open
        {
            get
            {
                return !string.IsNullOrEmpty(_open) && (_open == "true" || _open == "True");
            }
        }


        public class UserData
        {
            [JsonPropertyName("wld")]
            public int world { get; set; }

            [JsonPropertyName("unm")]
            public string userName { get; set; }

            [JsonPropertyName("gld")]
            public string guildName { get; set; }

            [JsonPropertyName("gwld")]
            public int guildWorld { get; set; }

            [JsonPropertyName("score")]
            public int score { get; set; }

            [JsonPropertyName("win")]
            public int win { get; set; }

            [JsonPropertyName("lose")]
            public int lose { get; set; }

            [JsonPropertyName("thmb")]
            public string thmb { get; set; }
        }
    }

}
