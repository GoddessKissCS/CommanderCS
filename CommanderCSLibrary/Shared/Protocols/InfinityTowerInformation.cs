﻿using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class InfinityTowerInformation
    {
        [JsonProperty("tinfo")]
        public InfinityTowerData infinityData { get; set; }

        [JsonIgnore]
        public string retryStage;
    }
}