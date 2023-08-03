using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EquipItemInfo
    {
        [JsonPropertyName("total")]
        public int totalCount { get; set; }

        [JsonPropertyName("avail")]
        public int availableCount { get; set; }

        [JsonPropertyName("list")]
        public List<int> equipCommanderList { get; set; }
    }
}
