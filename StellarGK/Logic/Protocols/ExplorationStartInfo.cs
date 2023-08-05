using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ExplorationStartInfo
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

        [JsonPropertyName("cid")]
        public List<string> cids { get; set; }
    }
}
