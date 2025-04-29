using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class GachaRatingDataTypeA
    {
        [JsonProperty("rating")]
        public float rating { get; set; }
    }
}