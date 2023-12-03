using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class SimpleCommanderInfo
    {
        [JsonProperty("cid")]
        public string id { get; set; }

        [JsonProperty("medl")]
        public int medal { get; set; }
    }
}