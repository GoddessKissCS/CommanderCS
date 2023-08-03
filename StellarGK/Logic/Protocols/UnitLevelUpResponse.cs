using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class UnitLevelUpResponse
    {
        [JsonPropertyName("gold")]
        public long gold { get; set; }

        [JsonPropertyName("abp")]
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

        [JsonPropertyName("nbp")]
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
