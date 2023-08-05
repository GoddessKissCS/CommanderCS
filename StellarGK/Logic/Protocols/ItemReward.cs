using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ItemReward
    {
        [JsonPropertyName("reward")]
        public SecretShop.ShopData shop { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }

        [JsonPropertyName("ursc")]
        public List<UserInformationResponse.PartData> ursc { get; set; }

        [JsonPropertyName("commMedl")]
        public Dictionary<string, SimpleCommanderInfo> commMedl { get; set; }
    }
}
