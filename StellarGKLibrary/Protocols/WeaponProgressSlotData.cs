﻿using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class WeaponProgressSlotData
    {
        [JsonProperty("slot")]
        public int slot { get; set; }

        [JsonProperty("remain")]
        public int remain { get; set; }
    }
}