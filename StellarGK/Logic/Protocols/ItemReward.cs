using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ItemReward
    {
        [JsonPropertyName("reward")]
        public SecretShop.ShopData shop;

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource rsoc;

        [JsonPropertyName("ursc")]
        public List<UserInformationResponse.PartData> ursc;

        [JsonPropertyName("commMedl")]
        public Dictionary<string, SimpleCommanderInfo> commMedl;
    }
}
