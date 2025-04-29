using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class ResourceRecharge
    {
        [JsonProperty("bult")]
        public RechargeData bulletData { get; set; }

        [JsonProperty("oil")]
        public RechargeData oilData { get; set; }

        [JsonProperty("skil")]
        public RechargeData skillData { get; set; }

        [JsonProperty("chip")]
        public RechargeData chip { get; set; }

        [JsonProperty("wmat1")]
        public RechargeData weaponMaterialData1 { get; set; }

        [JsonProperty("wmat2")]
        public RechargeData weaponMaterialData2 { get; set; }

        [JsonProperty("wmat3")]
        public RechargeData weaponMaterialData3 { get; set; }

        [JsonProperty("wmat4")]
        public RechargeData weaponMaterialData4 { get; set; }

        [JsonProperty("gacha")]
        public Dictionary<string, GachaInformationResponse> gacha { get; set; }

        [JsonProperty("world")]
        public int worldState { get; set; }

        public class RechargeData
        {
            [JsonProperty("cnt")]
            public int cnt { get; set; }

            [JsonProperty("remain")]
            public int remain { get; set; }
        }
    }
}