﻿using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class WeaponData
    {
        [JsonProperty("wid")]
        public string id { get; set; }

        [JsonProperty("wlv")]
        public int level { get; set; }

        [JsonProperty("cid")]
        public int cid { get; set; }
    }
}