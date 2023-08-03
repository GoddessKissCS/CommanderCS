using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ChannelData
    {
        [JsonPropertyName("openDt")]
        public double openTime { get; set; }

        [JsonPropertyName("maxLv")]
        public int maxLevel { get; set; }

        [JsonPropertyName("maxSt")]
        public string maxStage { get; set; }

        [JsonPropertyName("plcnt")]
        public string commanderCount { get; set; }

        [JsonPropertyName("svcnt")]
        public string serverCount { get; set; }
    }
}
