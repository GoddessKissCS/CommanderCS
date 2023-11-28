using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class PvPRankingList
    {
        [JsonProperty("rank")]
        public List<RankData> rankList { get; set; }

        [JsonProperty("user")]
        public RankingUserData user { get; set; }

        [JsonProperty("boss")]
        public List<Dictionary<string, int>> bossData { get; set; }

        [JsonProperty("info")]
        public RaidInfo info { get; set; }

        public class RankData
        {
            [JsonProperty("uno")]
            public int id { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("name")]
            public string _name { get; set; }

            [JsonProperty("thmb")]
            public string thumb { get; set; }

            [JsonProperty("score")]
            public int score { get; set; }

            [JsonProperty("grd")]
            public int grade { get; set; }

            [JsonProperty("rank")]
            public int rank { get; set; }

            [JsonProperty("rgts")]
            public int time { get; set; }

            [JsonProperty("gnm", NullValueHandling = NullValueHandling.Ignore)]
            public string guildName { get; set; }

            [JsonProperty("gwld")]
            public int guildServer { get; set; }

            [JsonProperty("rid")]
            public string replayId;
        }

        public class RaidInfo
        {
            [JsonProperty("etm")]
            public int endTime { get; set; }
        }
    }
}