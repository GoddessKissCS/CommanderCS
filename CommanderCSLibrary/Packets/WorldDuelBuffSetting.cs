using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Packets
{
    public class WorldDuelBuffSettingRequest
    {
        [JsonProperty("bbf")]
        public string Bbf { get; set; }
    }
}