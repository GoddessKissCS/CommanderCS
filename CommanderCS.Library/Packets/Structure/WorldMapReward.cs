using Newtonsoft.Json;

namespace CommanderCS.Library.Packets.Structure
{
    public class WorldMapRewardRequest
    {
        [JsonProperty("world")]
        public int world { get; set; }
    }
}