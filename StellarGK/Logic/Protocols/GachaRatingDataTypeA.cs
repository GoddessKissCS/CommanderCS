using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GachaRatingDataTypeA
    {
        [JsonProperty("rating")]
        public float rating { get; set; }
    }
}
