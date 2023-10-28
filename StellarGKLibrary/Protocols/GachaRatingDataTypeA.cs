using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class GachaRatingDataTypeA
    {
        [JsonProperty("rating")]
        public float rating { get; set; }
    }
}