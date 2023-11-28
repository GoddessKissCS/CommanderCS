using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class ItemReward
    {
        [JsonProperty("reward")]
        public SecretShop.ShopData shop { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }

        [JsonProperty("ursc")]
        public List<UserInformationResponse.PartData> ursc { get; set; }

        [JsonProperty("commMedl")]
        public Dictionary<string, SimpleCommanderInfo> commMedl { get; set; }
    }
}