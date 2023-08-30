using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class ExplorationStartInfo
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("cid")]
        public List<string> cids { get; set; }
    }
}
