using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class AchievementInfo
    {
        [JsonPropertyName("achv")]
        public List<AchievementData> AchievementList { get; set; }

        [JsonPropertyName("acg")]
        public int goal { get; set; }

        [JsonPropertyName("accc")]
        public int completeCount { get; set; }

        public class AchievementData
        {
            [JsonPropertyName("acid")]
            public int achievementId { get; set; }

            [JsonPropertyName("asot")]
            public int sort { get; set; }

            [JsonPropertyName("apt")]
            public int point { get; set; }

            [JsonPropertyName("fin")]
            public int complete { get; set; }

            [JsonPropertyName("arcv")]
            public int receive { get; set; }
        }
    }
}
