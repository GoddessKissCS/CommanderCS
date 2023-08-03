using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class UnitUpgradeResponse
    {
        [JsonPropertyName("ursc")]
        public List<UserInformationResponse.PartData> partData { get; set; }

        [JsonPropertyName("rsoc")]
        public Resource goodsInfo { get; set; }

        [JsonPropertyName("unit")]
        public Dictionary<string, Unit> unitInfo { get; set; }


        public class Resource
        {
            [JsonPropertyName("gold")]
            public string __gold { get; set; }

            [JsonPropertyName("abp")]
            public string __blueprintArmy { get; set; }
        }


        public class Unit
        {
            [JsonPropertyName("uid")]
            public string id;

            [JsonPropertyName("lv")]
            public int level;

            [JsonPropertyName("sklv")]
            public int sklv;
        }
    }
}
