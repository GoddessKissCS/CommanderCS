using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ResourceRecharge
    {
        [JsonPropertyName("bult")]
        public RechargeData bulletData;

        [JsonPropertyName("oil")]
        public RechargeData oilData;

        [JsonPropertyName("skil")]
        public RechargeData skillData;

        [JsonPropertyName("chip")]
        public RechargeData chip;

        [JsonPropertyName("wmat1")]
        public RechargeData weaponMaterialData1;

        [JsonPropertyName("wmat2")]
        public RechargeData weaponMaterialData2;

        [JsonPropertyName("wmat3")]
        public RechargeData weaponMaterialData3;

        [JsonPropertyName("wmat4")]
        public RechargeData weaponMaterialData4;

        [JsonPropertyName("gacha")]
        public Dictionary<string, GachaInformationResponse> gacha;

        [JsonPropertyName("world")]
        public int worldState;


        public class RechargeData
        {
            [JsonPropertyName("cnt")]
            public int cnt { get; set; }

            [JsonPropertyName("remain")]
            public int remain { get; set; }
        }
    }
}
