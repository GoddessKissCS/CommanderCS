using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class SellItemData
    {
        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("reward")]
        public List<RewardInfo.RewardData> rewardList { get; set; }

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

        [JsonPropertyName("weapon")]
        public Dictionary<string, WeaponData> weaponData { get; set; }

        [JsonPropertyName("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonPropertyName("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonPropertyName("drsoc")]
        public Dormitory.Resource dormitoryResource { get; set; }

        [JsonPropertyName("deco")]
        public Dictionary<string, int> dormitoryItemNormal { get; set; }

        [JsonPropertyName("sdeco")]
        public Dictionary<string, int> dormitoryItemAdvanced { get; set; }

        [JsonPropertyName("wall")]
        public Dictionary<string, int> dormitoryItemWallpaper { get; set; }

        [JsonPropertyName("bcos")]
        public Dictionary<string, int> dormitoryCostumeBody { get; set; }

        [JsonPropertyName("hcos")]
        public Dictionary<string, List<string>> dormitoryCostumeHead { get; set; }
    }
}
