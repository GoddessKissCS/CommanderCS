using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CooperateBattleRewardInfo : RewardInfo
    {
        [JsonPropertyName("coop")]
        public CooperateInfo coop { get; set; }

        [JsonPropertyName("recv")]
        public CooperateReceiveInfo recv { get; set; }
    }
}
