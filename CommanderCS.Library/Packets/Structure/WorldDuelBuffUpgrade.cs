using CommanderCS.Library.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Library.Packets
{
    public class WorldDuelBuffUpgradeRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class WorldDuelBuffUpgradeResponse
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }

        [JsonProperty("buff")]
        public Dictionary<string, int> buff { get; set; }
    }
}