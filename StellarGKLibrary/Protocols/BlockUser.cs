using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class BlockUser
    {
        [JsonProperty("ch")]
        public int channel { get; set; }

        [JsonProperty("uno")]
        public string uno { get; set; }

        [JsonProperty("nick")]
        public string nickName { get; set; }

        [JsonProperty("thumb")]
        public string thumbnail { get; set; }
    }
}