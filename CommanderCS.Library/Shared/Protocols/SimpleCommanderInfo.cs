using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class SimpleCommanderInfo
    {
        [JsonProperty("cid")]
        public string id { get; set; }

        [JsonProperty("medl")]
        public int medal { get; set; }
    }
}