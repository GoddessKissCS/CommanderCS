using Newtonsoft.Json;

namespace CommanderCS.Library.Packets.Structure
{
    public class WorldDuelBuffSettingRequest
    {
        [JsonProperty("bbf")]
        public string Bbf { get; set; }
    }
}