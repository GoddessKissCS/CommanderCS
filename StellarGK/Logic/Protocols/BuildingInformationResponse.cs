using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class BuildingInformationResponse
    {
        [JsonPropertyName("bid")]
        public EBuilding buildType { get; set; }

        [JsonPropertyName("stus")]
        public int stateCode { get; set; }

        [JsonPropertyName("lv")]
        public int level { get; set; }

        [JsonPropertyName("remain")]
        public int remainTime { get; set; }
    }
}
