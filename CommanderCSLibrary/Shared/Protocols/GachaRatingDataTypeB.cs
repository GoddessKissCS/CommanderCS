using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class GachaRatingDataTypeB
    {
        [JsonProperty("list")]
        public Dictionary<string, Dictionary<int, float>> list { get; set; }
    }
}