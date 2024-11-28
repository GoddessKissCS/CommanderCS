using Newtonsoft.Json;

namespace CommanderCSLibrary.Packets
{
    public class WorldDuelBuffSettingRequest
    {
        [JsonProperty("bbf")]
        public string Bbf { get; set; }
    }
}