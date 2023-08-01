using Newtonsoft.Json;
using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BuildingInformationResponse
    {
        [JsonProperty("bid")]
        public EBuilding buildType { get; set; }

        [JsonProperty("stus")]
        public int stateCode { get; set; }

        [JsonProperty("lv")]
        public int level { get; set; }

        [JsonProperty("remain")]
        public int remainTime { get; set; }
    }
}
