using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Packets
{
    public class PvPStartWorldDuelRequest
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("retry")]
        public int retry { get; set; }

        [JsonProperty("deck")]
        public JObject deck { get; set; }

        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("checkSum")]
        public string checkSum { get; set; }

        [JsonProperty("info")]
        public JArray info { get; set; }

        [JsonProperty("result")]
        public JArray result { get; set; }
    }
}