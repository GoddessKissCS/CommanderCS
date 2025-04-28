using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class ExplorationStartInfo
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("cid")]
        public List<string> cids { get; set; }
    }
}