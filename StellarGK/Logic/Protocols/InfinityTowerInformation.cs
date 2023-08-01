using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class InfinityTowerInformation
    {
        [JsonProperty("tinfo")]
        public InfinityTowerData infinityData { get; set; }

        [JsonIgnore]
        public string retryStage;
    }
}
