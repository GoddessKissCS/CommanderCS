using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class PlunderTimeMachine
    {
        [JsonProperty("reward")]
        public List<List<RewardInfo.RewardData>> reward { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

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

        [JsonProperty("vshp")]
        public int VipShopOpen { get; set; }

        [JsonProperty("vrtm")]
        public int VipShopRemainTime { get; set; }

        [JsonProperty("guit")]
        public Dictionary<string, int> groupItemData { get; set; }
    }
}