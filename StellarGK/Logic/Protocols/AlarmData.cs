using System.Text.Json.Serialization;
using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{

    public class AlarmData
    {
        [JsonPropertyName("dcnt")]
        public int dcnt { get; set; }

        [JsonPropertyName("hold")]
        public HoldData hold { get; set; }

        [JsonPropertyName("cmdr")]
        public int cmdr { get; set; }

        [JsonPropertyName("shop")]
        public Dictionary<EShopType, int> shop { get; set; }

        [JsonPropertyName("expd")]
        public int expd { get; set; }

        [JsonPropertyName("mwdw")]
        public int mwdw { get; set; }

        [JsonPropertyName("srgs")]
        public int srgs { get; set; }

        [JsonPropertyName("srge")]
        public int srge { get; set; }

        [JsonPropertyName("ocps")]
        public int ocps { get; set; }

        [JsonPropertyName("ocpe")]
        public int ocpe { get; set; }

        [JsonPropertyName("raid")]
        public int raid { get; set; }

        [JsonPropertyName("arena")]
        public int arena { get; set; }


        public class HoldData
        {
            [JsonPropertyName("cnt")]
            public int count { get; set; }

            [JsonPropertyName("time")]
            public int time { get; set; }
        }
    }
}
