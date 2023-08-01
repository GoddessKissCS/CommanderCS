using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WeaponData
    {
        [JsonProperty("wid")]
        public string id { get; set; }

        [JsonProperty("wlv")]
        public int level { get; set; }

        [JsonProperty("cid")]
        public int cid { get; set; }
    }
}
