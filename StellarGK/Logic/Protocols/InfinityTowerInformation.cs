using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class InfinityTowerInformation
    {
        [JsonPropertyName("tinfo")]
        public InfinityTowerData infinityData { get; set; }

        [JsonIgnore]
        public string retryStage;
    }
}
