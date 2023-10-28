using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class InfinityTowerInformation
    {
        [JsonProperty("tinfo")]
        public InfinityTowerData infinityData { get; set; }

        [JsonIgnore]
        public string retryStage;
    }
}