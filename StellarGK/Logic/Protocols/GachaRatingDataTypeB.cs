using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GachaRatingDataTypeB
    {
        [JsonPropertyName("list")]
        public Dictionary<string, Dictionary<int, float>> list { get; set; }
    }
}
