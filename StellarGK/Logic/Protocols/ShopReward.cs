using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class ShopReward
    {
        [JsonPropertyName("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonPropertyName("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonPropertyName("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonPropertyName("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonPropertyName("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonPropertyName("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonPropertyName("shop")]
        public SecretShop.ShopData shop;

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource rsoc;
    }
}
