using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class BuyVipShop
    {
        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("uifo")]
        public UserInformationResponse.BattleStatistics userInfo { get; set; }
    }
}
