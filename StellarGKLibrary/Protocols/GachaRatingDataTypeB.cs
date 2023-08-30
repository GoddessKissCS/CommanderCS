using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class GachaRatingDataTypeB
    {
        [JsonProperty("list")]
        public Dictionary<string, Dictionary<int, float>> list { get; set; }
    }
}
