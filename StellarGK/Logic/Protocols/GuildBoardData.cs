using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class GuildBoardData
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

        [JsonPropertyName("msg")]
        public string msg { get; set; }

        [JsonPropertyName("regdt")]
        public double regdt { get; set; }

        [JsonPropertyName("uno")]
        public int uno { get; set; }

        [JsonPropertyName("thumb")]
        public string thumb { get; set; }

        [JsonPropertyName("unm")]
        public string unm { get; set; }

        [JsonPropertyName("dauth")]
        public int dauth { get; set; }
    }
}
