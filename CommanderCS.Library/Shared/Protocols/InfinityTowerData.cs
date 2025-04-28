using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class InfinityTowerData
    {
        [JsonProperty("pifid")]
        public string curField { get; set; }

        [JsonProperty("field")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}