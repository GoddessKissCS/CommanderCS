using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class GachaRatingDataTypeA
    {
        [JsonProperty("rating")]
        public float rating { get; set; }
    }
}