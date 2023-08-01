using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BuyVipShop
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("uifo")]
        public UserInformationResponse.BattleStatistics userInfo { get; set; }
    }
}
