using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class SimpleCommanderInfo
    {
        [JsonPropertyName("cid")]
        public string id { get; set; }

        [JsonPropertyName("medl")]
        public int medal { get; set; }
    }
}
