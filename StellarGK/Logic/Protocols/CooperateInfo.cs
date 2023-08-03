using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CooperateInfo
    {
        [JsonPropertyName("stage")]
        public int stage { get; set; }

        [JsonPropertyName("step")]
        public int step { get; set; }

        [JsonPropertyName("remain")]
        public int remain { get; set; }

        [JsonPropertyName("dmg")]
        public ulong dmg { get; set; }

        [JsonPropertyName("ticket")]
        public int ticket { get; set; }
    }
}
