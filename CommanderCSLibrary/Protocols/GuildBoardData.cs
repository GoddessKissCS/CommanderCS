using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class GuildBoardData
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("msg")]
        public string msg { get; set; }

        [JsonProperty("regdt")]
        public double regdt { get; set; }

        [JsonProperty("uno")]
        public int uno { get; set; }

        [JsonProperty("thumb")]
        public string thumb { get; set; }

        [JsonProperty("unm")]
        public string unm { get; set; }

        [JsonProperty("dauth")]
        public int dauth { get; set; }
    }
}