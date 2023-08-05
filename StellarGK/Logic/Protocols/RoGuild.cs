using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{
    public class RoGuild
    {

        [JsonPropertyName("list")]
        public string list { get; set; }

        [JsonPropertyName("gidx")]
        public int gidx { get; set; }

        [JsonPropertyName("gnm")]
        public string gnm { get; set; }

        [JsonPropertyName("ntc")]
        public string ntc { get; set; }

        [JsonPropertyName("lev")]
        public int lev { get; set; }

        [JsonPropertyName("apnt")]
        public int apnt { get; set; }

        [JsonPropertyName("emb")]
        public int emb { get; set; }

        [JsonPropertyName("gtyp")]
        public int gtyp { get; set; }

        [JsonPropertyName("mxCnt")]
        public int mxCnt { get; set; }

        [JsonPropertyName("cnt")]
        public int cnt { get; set; }
        [JsonPropertyName("world")]
        public int world { get; set; }
    }
}
