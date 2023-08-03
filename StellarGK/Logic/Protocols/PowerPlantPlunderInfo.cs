using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class PowerPlantPlunderInfo
    {
        [JsonPropertyName("pRemain")]
        public int remain { get; set; }

        [JsonPropertyName("target")]
        public UserInformationResponse.Commander target { get; set; }
    }
}
