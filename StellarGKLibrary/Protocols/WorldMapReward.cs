﻿using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class WorldMapReward
    {
        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }
    }
}