using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UnitLevelUpResponse
    {
        [JsonProperty("gold")]
        public long gold { get; set; }

        [JsonProperty("abp")]
        public string __blueprintArmy { get; set; }

        public int blueprintArmy
        {
            get
            {
                if (string.IsNullOrEmpty(__blueprintArmy))
                {
                    return -1;
                }
                return int.Parse(__blueprintArmy);
            }
        }

        [JsonProperty("nbp")]
        public string __blueprintNavy { get; set; }

        public int blueprintNavy
        {
            get
            {
                if (string.IsNullOrEmpty(__blueprintNavy))
                {
                    return -1;
                }
                return int.Parse(__blueprintNavy);
            }
        }
    }

}
