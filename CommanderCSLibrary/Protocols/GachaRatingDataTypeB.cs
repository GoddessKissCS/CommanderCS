using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class GachaRatingDataTypeB
    {
        [JsonProperty("list")]
        public Dictionary<string, Dictionary<int, float>> list { get; set; }
    }
}