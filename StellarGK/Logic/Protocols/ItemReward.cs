using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemReward
    {
        [JsonProperty("reward")]
        public SecretShop.ShopData shop;

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc;

        [JsonProperty("ursc")]
        public List<UserInformationResponse.PartData> ursc;

        [JsonProperty("commMedl")]
        public Dictionary<string, SimpleCommanderInfo> commMedl;
    }
}
