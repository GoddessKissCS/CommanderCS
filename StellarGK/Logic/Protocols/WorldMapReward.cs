using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class WorldMapReward
    {
        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }
    }
}
