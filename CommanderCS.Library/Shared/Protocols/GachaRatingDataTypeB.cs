using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class GachaRatingDataTypeB
    {
        [JsonProperty("list")]
        public Dictionary<string, Dictionary<int, float>> list { get; set; }
    }
}