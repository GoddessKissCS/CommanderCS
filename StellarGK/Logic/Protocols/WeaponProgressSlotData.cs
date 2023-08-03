using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{
    public class WeaponProgressSlotData
    {
        [JsonPropertyName("slot")]
        public int slot { get; set; }

        [JsonPropertyName("remain")]
        public int remain { get; set; }
    }
}
