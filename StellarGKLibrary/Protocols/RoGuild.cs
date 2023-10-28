using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class RoGuild
    {
        [JsonProperty("list")]
        public string list { get; set; }

        [JsonProperty("gidx")]
        public int gidx { get; set; }

        [JsonProperty("gnm")]
        public string gnm { get; set; }

        [JsonProperty("ntc")]
        public string ntc { get; set; }

        [JsonProperty("lev")]
        public int lev { get; set; }

        [JsonProperty("apnt")]
        public int apnt { get; set; }

        [JsonProperty("emb")]
        public int emb { get; set; }

        [JsonProperty("gtyp")]
        public int gtyp { get; set; }

        [JsonProperty("mxCnt")]
        public int mxCnt { get; set; }

        [JsonProperty("cnt")]
        public int cnt { get; set; }

        [JsonProperty("world")]
        public int world { get; set; }
    }
}