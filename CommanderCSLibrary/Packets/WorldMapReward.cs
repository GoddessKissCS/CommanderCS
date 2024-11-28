using Newtonsoft.Json;

namespace CommanderCSLibrary.Packets
{
    public class WorldMapRewardRequest
    {
        [JsonProperty("world")]
        public int world { get; set; }
    }
}