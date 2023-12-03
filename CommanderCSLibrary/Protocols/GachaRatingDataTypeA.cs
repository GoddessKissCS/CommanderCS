using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class GachaRatingDataTypeA
    {
        [JsonProperty("rating")]
        public float rating { get; set; }
    }
}