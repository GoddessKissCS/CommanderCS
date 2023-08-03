using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CooperateBattleData
    {
        [JsonPropertyName("coop")]
        public CooperateInfo coop { get; set; }

        [JsonPropertyName("recv")]
        public CooperateReceiveInfo recv { get; set; }
    }
}
