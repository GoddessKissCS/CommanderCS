using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class FavorUpData
    {
        [JsonProperty("todayFavr")]
        public int todayFavorCount { get; set; }

        [JsonProperty("favr")]
        public List<CommanderFavor> commanderFavor { get; set; }

        public class CommanderFavor
        {
        }
    }
}