using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PowerPlantPlunderInfo
    {
        [JsonProperty("pRemain")]
        public int remain { get; set; }

        [JsonProperty("target")]
        public UserInformationResponse.Commander target { get; set; }
    }
}
