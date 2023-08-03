using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class VipGacha
    {
        [JsonPropertyName("list")]
        public Dictionary<string, VipGachaInfo> VipGachaInfoList { get; set; }

        [JsonPropertyName("cnt")]
        public int gachaCount { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonPropertyName("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonPropertyName("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonPropertyName("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonPropertyName("gacha")]
        public List<VipGachaResult> gacharesult { get; set; }

        [JsonPropertyName("rtm")]
        public int refreshTime { get; set; }

        public class VipGachaInfo
        {
            [JsonPropertyName("rwdType")]
            public int rewardType { get; set; }

            [JsonPropertyName("rwdIdx")]
            public int rewardIdx { get; set; }

            [JsonPropertyName("rwdCnt")]
            public int rewardCount { get; set; }

            [JsonPropertyName("rwdRate")]
            public int rewardRate { get; set; }

            [JsonPropertyName("rwdPoint")]
            public float rewardPoint { get; set; }
        }

        public class VipGachaResult
        {
            [JsonPropertyName("type")]
            public int rewardType_result { get; set; }

            [JsonPropertyName("idx")]
            public int rewardIdx_result { get; set; }

            [JsonPropertyName("cnt")]
            public int rewardCount_result { get; set; }
        }
    }

}
