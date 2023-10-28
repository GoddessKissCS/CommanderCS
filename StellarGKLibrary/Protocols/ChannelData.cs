using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class ChannelData
    {
        [JsonProperty("openDt")]
        public double openTime { get; set; }

        [JsonProperty("maxLv")]
        public int maxLevel { get; set; }

        [JsonProperty("maxSt")]
        public string maxStage { get; set; }

        [JsonProperty("plcnt")]
        public string commanderCount { get; set; }

        [JsonProperty("svcnt")]
        public string serverCount { get; set; }
    }
}