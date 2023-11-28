using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class InfinityTowerInformation
    {
        [JsonProperty("tinfo")]
        public InfinityTowerData infinityData { get; set; }

        [JsonIgnore]
        public string retryStage;
    }
}