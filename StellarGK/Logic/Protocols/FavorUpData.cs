using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FavorUpData
    {
        [JsonProperty("todayFavr")]
        public int todayFavorCount { get; set; }

        [JsonProperty("favr")]
        public List<CommanderFavor> commanderFavor { get; set; }

        [JsonObject(MemberSerialization.OptIn)]
        public class CommanderFavor
        {
        }
    }
}
