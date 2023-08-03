using System.Text.Json.Serialization;
using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{

    public class SecretShop
    {
        [JsonPropertyName("shop")]
        public List<ShopData> shopList { get; set; }

        [JsonPropertyName("rtime")]
        public int refreshTime { get; set; }

        [JsonPropertyName("rcnt")]
        public int refreshCount { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("vrcnt")]
        public int reset { get; set; }


        public class ShopData
        {
            [JsonPropertyName("id")]
            public int id { get; set; }

            [JsonPropertyName("sptp")]
            public ERewardType type { get; set; }

            [JsonPropertyName("spid")]
            public int idx { get; set; }

            [JsonPropertyName("amnt")]
            public int count { get; set; }

            [JsonPropertyName("ptyp")]
            public EPriceType costType { get; set; }

            [JsonPropertyName("prc")]
            public int cost { get; set; }

            [JsonPropertyName("sold")]
            public int sold { get; set; }

            [JsonPropertyName("rtime")]
            public int time { get; set; }
        }
    }
}
