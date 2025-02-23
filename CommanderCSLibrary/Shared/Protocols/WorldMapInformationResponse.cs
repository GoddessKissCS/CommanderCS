﻿using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class WorldMapInformationResponse
    {
        [JsonProperty("mid")]
        public string stageId { get; set; }

        [JsonProperty("cnt")]
        public int clearCount { get; set; }

        [JsonProperty("star")]
        public int star { get; set; }
    }
}