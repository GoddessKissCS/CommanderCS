using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class GachaRatingDataTypeA
    {
        [JsonProperty("rating")]
        public float rating { get; set; }
    }
}