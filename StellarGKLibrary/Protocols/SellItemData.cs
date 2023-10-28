using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class SellItemData
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("reward")]
        public List<RewardInfo.RewardData> rewardList { get; set; }

        [JsonProperty("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonProperty("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonProperty("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonProperty("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonProperty("weapon")]
        public Dictionary<string, WeaponData> weaponData { get; set; }

        [JsonProperty("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonProperty("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonProperty("drsoc")]
        public Dormitory.Resource dormitoryResource { get; set; }

        [JsonProperty("deco")]
        public Dictionary<string, int> dormitoryItemNormal { get; set; }

        [JsonProperty("sdeco")]
        public Dictionary<string, int> dormitoryItemAdvanced { get; set; }

        [JsonProperty("wall")]
        public Dictionary<string, int> dormitoryItemWallpaper { get; set; }

        [JsonProperty("bcos")]
        public Dictionary<string, int> dormitoryCostumeBody { get; set; }

        [JsonProperty("hcos")]
        public Dictionary<string, List<string>> dormitoryCostumeHead { get; set; }
    }
}