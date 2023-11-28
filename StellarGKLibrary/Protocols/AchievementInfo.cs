using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class AchievementInfo
    {
        [JsonProperty("achv")]
        public List<AchievementData> AchievementList { get; set; }

        [JsonProperty("acg")]
        public int goal { get; set; }

        [JsonProperty("accc")]
        public int completeCount { get; set; }

        public class AchievementData
        {
            [JsonProperty("acid")]
            public int achievementId { get; set; }

            [JsonProperty("asot")]
            public int sort { get; set; }

            [JsonProperty("apt")]
            public int point { get; set; }

            [JsonProperty("fin")]
            public int complete { get; set; }

            [JsonProperty("arcv")]
            public int receive { get; set; }
        }
    }
}