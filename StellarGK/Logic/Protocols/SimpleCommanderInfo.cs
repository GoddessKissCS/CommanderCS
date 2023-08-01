using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SimpleCommanderInfo
    {
        [JsonProperty("cid")]
        public string id { get; set; }

        [JsonProperty("medl")]
        public int medal { get; set; }
    }
}
