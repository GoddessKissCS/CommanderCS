using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class InfinityTowerInformation
    {
        [JsonProperty("tinfo")]
        public InfinityTowerData infinityData { get; set; }

        [JsonIgnore]
        public string retryStage;
    }
}