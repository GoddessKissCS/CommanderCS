using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class MoveConquestTroop
    {
        [JsonPropertyName("path")]
        public List<int> path { get; set; }

        [JsonPropertyName("distance")]
        public int distance { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }

        [JsonPropertyName("ucash")]
        public int ucash { get; set; }
    }
}
