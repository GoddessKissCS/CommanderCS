using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class CommanderRankUpResponse
    {
        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> comm { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource rsoc;

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medl;
    }
}
