using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Library.Packets.Structure
{
    public class WorldDuelDefenderSettingRequest
    {
        [JsonProperty("deck")]
        public JObject Deck { get; set; }
    }
}