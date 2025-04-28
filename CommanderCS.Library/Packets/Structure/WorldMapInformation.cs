using CommanderCS.Library.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Library.Packets.Structure
{
    public class WorldMapInformationRequest
    {
        [JsonProperty("world")]
        public int world { get; set; }
    }

    public class WorldMapResponse
    {
        [JsonProperty("stage")]
        public List<WorldMapInformationResponse> stage { get; set; }

        [JsonProperty("rwd")]
        public int rwd { get; set; }
    }
}