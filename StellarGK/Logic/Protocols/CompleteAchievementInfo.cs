using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CompleteAchievementInfo
    {
        [JsonProperty("acid")]
        public int achievementId { get; set; }

        [JsonProperty("asot")]
        public int sort { get; set; }

        [JsonProperty("gts")]
        public int time { get; set; }
    }
}
