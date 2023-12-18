using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class SecretShop
    {
        [JsonProperty("shop")]
        public List<ShopData> shopList { get; set; }

        [JsonProperty("rtime")]
        public int refreshTime { get; set; }

        [JsonProperty("rcnt")]
        public int refreshCount { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("vrcnt")]
        public int reset { get; set; }

        public class ShopData
        {
            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("sptp")]
            public ERewardType type { get; set; }

            [JsonProperty("spid")]
            public int idx { get; set; }

            [JsonProperty("amnt")]
            public int count { get; set; }

            [JsonProperty("ptyp")]
            public EPriceType costType { get; set; }

            [JsonProperty("prc")]
            public int cost { get; set; }

            [JsonProperty("sold")]
            public int sold { get; set; }

            [JsonProperty("rtime")]
            public int time { get; set; }
        }
    }
}