using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class VipGacha
    {
        [JsonProperty("list")]
        public Dictionary<string, VipGachaInfo> VipGachaInfoList { get; set; }

        [JsonProperty("cnt")]
        public int gachaCount { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonProperty("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonProperty("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonProperty("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonProperty("gacha")]
        public List<VipGachaResult> gacharesult { get; set; }

        [JsonProperty("rtm")]
        public int refreshTime { get; set; }

        public class VipGachaInfo
        {
            [JsonProperty("rwdType")]
            public int rewardType { get; set; }

            [JsonProperty("rwdIdx")]
            public int rewardIdx { get; set; }

            [JsonProperty("rwdCnt")]
            public int rewardCount { get; set; }

            [JsonProperty("rwdRate")]
            public int rewardRate { get; set; }

            [JsonProperty("rwdPoint")]
            public float rewardPoint { get; set; }
        }

        public class VipGachaResult
        {
            [JsonProperty("type")]
            public int rewardType_result { get; set; }

            [JsonProperty("idx")]
            public int rewardIdx_result { get; set; }

            [JsonProperty("cnt")]
            public int rewardCount_result { get; set; }
        }
    }
}