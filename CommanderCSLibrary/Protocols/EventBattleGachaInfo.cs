﻿using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class EventBattleGachaInfo
    {
        [JsonProperty("season")]
        public int season { get; set; }

        [JsonProperty("reset")]
        public int reset { get; set; }

        [JsonProperty("info")]
        public Dictionary<int, int> info { get; set; }
    }
}