using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class UnitLevelUpResponse
    {
        [JsonProperty("gold")]
        public long gold { get; set; }

        [JsonProperty("abp")]
        public string __blueprintArmy { get; set; }

        [JsonProperty("nbp")]
        public string __blueprintNavy { get; set; }
    }
}