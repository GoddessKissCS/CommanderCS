using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Packets
{
    public class WorldDuelDefenderSettingRequest
    {
        [JsonProperty("deck")]
        public JObject Deck { get; set; }
    }
}