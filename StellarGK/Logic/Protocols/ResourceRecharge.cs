using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ResourceRecharge
    {
        [JsonPropertyName("bult")]
        public RechargeData bulletData { get; set; }

        [JsonPropertyName("oil")]
        public RechargeData oilData { get; set; }

        [JsonPropertyName("skil")]
        public RechargeData skillData { get; set; }

        [JsonPropertyName("chip")]
        public RechargeData chip { get; set; }

        [JsonPropertyName("wmat1")]
        public RechargeData weaponMaterialData1 { get; set; }

        [JsonPropertyName("wmat2")]
        public RechargeData weaponMaterialData2 { get; set; }

        [JsonPropertyName("wmat3")]
        public RechargeData weaponMaterialData3 { get; set; }

        [JsonPropertyName("wmat4")]
        public RechargeData weaponMaterialData4 { get; set; }

        [JsonPropertyName("gacha")]
        public Dictionary<string, GachaInformationResponse> gacha { get; set; }

        [JsonPropertyName("world")]
        public int worldState { get; set; }
        public class RechargeData
        {
            [JsonPropertyName("cnt")]
            public int cnt { get; set; }

            [JsonPropertyName("remain")]
            public int remain { get; set; }
        }
    }
}
