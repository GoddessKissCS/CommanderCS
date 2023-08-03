using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class PlunderTimeMachine
    {
        [JsonPropertyName("reward")]
        public List<List<RewardInfo.RewardData>> reward { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

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

        [JsonPropertyName("vshp")]
        public int VipShopOpen { get; set; }

        [JsonPropertyName("vrtm")]
        public int VipShopRemainTime { get; set; }

        [JsonPropertyName("guit")]
        public Dictionary<string, int> groupItemData { get; set; }
    }
}
