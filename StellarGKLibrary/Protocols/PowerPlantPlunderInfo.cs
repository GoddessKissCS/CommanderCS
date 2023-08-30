using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class PowerPlantPlunderInfo
    {
        [JsonProperty("pRemain")]
        public int remain { get; set; }

        [JsonProperty("target")]
        public UserInformationResponse.Commander target { get; set; }
    }
}
