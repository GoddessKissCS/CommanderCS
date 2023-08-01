using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ResourceRecharge
    {
        [JsonProperty("bult")]
        public RechargeData bulletData;

        [JsonProperty("oil")]
        public RechargeData oilData;

        [JsonProperty("skil")]
        public RechargeData skillData;

        [JsonProperty("chip")]
        public RechargeData chip;

        [JsonProperty("wmat1")]
        public RechargeData weaponMaterialData1;

        [JsonProperty("wmat2")]
        public RechargeData weaponMaterialData2;

        [JsonProperty("wmat3")]
        public RechargeData weaponMaterialData3;

        [JsonProperty("wmat4")]
        public RechargeData weaponMaterialData4;

        [JsonProperty("gacha")]
        public Dictionary<string, GachaInformationResponse> gacha;

        [JsonProperty("world")]
        public int worldState;

        [JsonObject(MemberSerialization.OptIn)]
        public class RechargeData
        {
            [JsonProperty("cnt")]
            public int cnt { get; set; }

            [JsonProperty("remain")]
            public int remain { get; set; }
        }
    }
}
