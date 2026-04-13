using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class WeaponData
    {
        [JsonProperty("wid")]
        public string weapon_id { get; set; }

        [JsonProperty("wlv")]
        public int weapon_level { get; set; }

        [JsonProperty("cid")]
        public int commander_id { get; set; }
    }
}