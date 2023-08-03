using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CompleteAchievementInfo
    {
        [JsonPropertyName("acid")]
        public int achievementId { get; set; }

        [JsonPropertyName("asot")]
        public int sort { get; set; }

        [JsonPropertyName("gts")]
        public int time { get; set; }
    }
}
