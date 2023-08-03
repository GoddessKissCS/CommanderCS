using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class BlockUser
    {
        [JsonPropertyName("ch")]
        public int channel { get; set; }

        [JsonPropertyName("uno")]
        public string uno { get; set; }

        [JsonPropertyName("nick")]
        public string nickName { get; set; }

        [JsonPropertyName("thumb")]
        public string thumbnail { get; set; }
    }
}
