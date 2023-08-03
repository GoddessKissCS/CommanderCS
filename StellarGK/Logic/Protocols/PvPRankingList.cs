using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class PvPRankingList
    {
        [JsonPropertyName("rank")]
        public List<RankData> rankList { get; set; }

        [JsonPropertyName("user")]
        public RankingUserData user { get; set; }

        [JsonPropertyName("boss")]
        public List<Dictionary<string, int>> bossData { get; set; }

        [JsonPropertyName("info")]
        public RaidInfo info { get; set; }


        public class RankData
        {
            [JsonPropertyName("uno")]
            public int id { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("name")]
            public string _name { get; set; }

            [JsonPropertyName("thmb")]
            public string thumb { get; set; }

            [JsonPropertyName("score")]
            public int score { get; set; }

            [JsonPropertyName("grd")]
            public int grade { get; set; }

            [JsonPropertyName("rank")]
            public int rank { get; set; }

            [JsonPropertyName("rgts")]
            public int time { get; set; }

            [JsonPropertyName("gnm")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string guildName { get; set; }

            [JsonPropertyName("gwld")]
            public int guildServer { get; set; }

            [JsonPropertyName("rid")]
            public string replayId;
        }


        public class RaidInfo
        {
            [JsonPropertyName("etm")]
            public int endTime { get; set; }
        }
    }
}
