using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class BuyVipShop
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("uifo")]
        public UserInformationResponse.BattleStatistics userInfo { get; set; }
    }
}
