using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class UnitUpgradeResponse
    {
        [JsonProperty("ursc")]
        public List<UserInformationResponse.PartData> partData { get; set; }

        [JsonProperty("rsoc")]
        public Resource goodsInfo { get; set; }

        [JsonProperty("unit")]
        public Dictionary<string, Unit> unitInfo { get; set; }

        public class Resource
        {
            [JsonProperty("gold")]
            public string __gold { get; set; }

            [JsonProperty("abp")]
            public string __blueprintArmy { get; set; }
        }

        public class Unit
        {
            [JsonProperty("uid")]
            public string id;

            [JsonProperty("lv")]
            public int level;

            [JsonProperty("sklv")]
            public int sklv;
        }
    }
}