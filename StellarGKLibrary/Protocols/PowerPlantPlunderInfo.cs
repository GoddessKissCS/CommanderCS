using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class PowerPlantPlunderInfo
    {
        [JsonProperty("pRemain")]
        public int remain { get; set; }

        [JsonProperty("target")]
        public UserInformationResponse.Commander target { get; set; }
    }
}