using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Packets
{
    public class WorldDuelDefenderSettingRequest
    {
        [JsonProperty("deck")]
        public JObject Deck { get; set; }
    }
}