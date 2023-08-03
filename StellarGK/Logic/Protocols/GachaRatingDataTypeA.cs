using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GachaRatingDataTypeA
    {
        [JsonPropertyName("rating")]
        public float rating { get; set; }
    }
}
