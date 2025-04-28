using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class EquipItemInfo
    {
        [JsonProperty("total")]
        public int totalCount { get; set; }

        [JsonProperty("avail")]
        public int availableCount { get; set; }

        [JsonProperty("list")]
        public List<int> equipCommanderList { get; set; }
    }
}