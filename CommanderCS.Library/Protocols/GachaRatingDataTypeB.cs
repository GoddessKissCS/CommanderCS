using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class GachaRatingDataTypeB
    {
        [JsonProperty("list")]
        public Dictionary<string, Dictionary<int, float>> list { get; set; }
    }
}