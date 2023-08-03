using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class WeaponData
    {
        [JsonPropertyName("wid")]
        public string id { get; set; }

        [JsonPropertyName("wlv")]
        public int level { get; set; }

        [JsonPropertyName("cid")]
        public int cid { get; set; }
    }
}
