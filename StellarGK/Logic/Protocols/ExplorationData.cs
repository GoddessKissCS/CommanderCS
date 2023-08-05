using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ExplorationData
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

        [JsonPropertyName("rmtm")]
        public double remainTime { get; set; }

        [JsonPropertyName("cid")]
        public List<string> cids { get; set; }
    }

}
