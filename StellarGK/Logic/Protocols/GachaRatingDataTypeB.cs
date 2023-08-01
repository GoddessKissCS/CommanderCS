using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GachaRatingDataTypeB
    {
        [JsonProperty("list")]
        public Dictionary<string, Dictionary<int, float>> list { get; set; }
    }
}
