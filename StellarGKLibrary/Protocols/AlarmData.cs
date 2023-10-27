using Newtonsoft.Json;
using StellarGKLibrary.Enum;

namespace StellarGKLibrary.Protocols
{

    public class AlarmData
    {
        [JsonProperty("dcnt")]
        public int dcnt { get; set; }

        [JsonProperty("hold")]
        public HoldData hold { get; set; }

        [JsonProperty("cmdr")]
        public int cmdr { get; set; }

        [JsonProperty("shop")]
        public Dictionary<EShopType, int> shop { get; set; }

        [JsonProperty("expd")]
        public int expd { get; set; }

        [JsonProperty("mwdw")]
        public int mwdw { get; set; }

        [JsonProperty("srgs")]
        public int srgs { get; set; }

        [JsonProperty("srge")]
        public int srge { get; set; }

        [JsonProperty("ocps")]
        public int ocps { get; set; }

        [JsonProperty("ocpe")]
        public int ocpe { get; set; }

        [JsonProperty("raid")]
        public int raid { get; set; }

        [JsonProperty("arena")]
        public int arena { get; set; }

        public class HoldData
        {
            [JsonProperty("cnt")]
            public int count { get; set; }

            [JsonProperty("time")]
            public int time { get; set; }
        }
    }
}
