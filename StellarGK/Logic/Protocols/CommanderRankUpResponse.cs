using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{

    [JsonObject(MemberSerialization.OptIn)]
    public class CommanderRankUpResponse
    {
        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> comm { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc;

        [JsonProperty("medl")]
        public Dictionary<string, int> medl;
    }
}
