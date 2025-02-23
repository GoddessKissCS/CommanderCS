﻿using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class ExplorationData
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("rmtm")]
        public double remainTime { get; set; }

        [JsonProperty("cid")]
        public List<string> cids { get; set; }
    }
}