﻿using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
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