using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class InfinityTowerData
    {
        [JsonProperty("pifid")]
        public string curField { get; set; }

        [JsonProperty("field")]
        public Dictionary<string, Dictionary<int, int>> fieldData { get; set; }
    }
}
