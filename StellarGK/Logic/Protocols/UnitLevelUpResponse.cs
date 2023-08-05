using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class UnitLevelUpResponse
    {
        [JsonPropertyName("gold")]
        public long gold { get; set; }

        [JsonPropertyName("abp")]
        public string __blueprintArmy { get; set; }

        [JsonPropertyName("nbp")]
        public string __blueprintNavy { get; set; }

    }

}
