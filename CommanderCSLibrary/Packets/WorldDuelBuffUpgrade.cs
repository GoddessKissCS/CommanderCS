using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCSLibrary.Packets
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