using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class InfinityTowerData
    {
        [JsonPropertyName("pifid")]
        public string curField { get; set; }

        [JsonPropertyName("field")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}
