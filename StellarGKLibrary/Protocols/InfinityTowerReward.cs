﻿using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class InfinityTowerReward : RewardInfo
    {
        [JsonProperty("tinfo")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}