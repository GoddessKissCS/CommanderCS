using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class FavorUpData
    {
        [JsonPropertyName("todayFavr")]
        public int todayFavorCount { get; set; }

        [JsonPropertyName("favr")]
        public List<CommanderFavor> commanderFavor { get; set; }


        public class CommanderFavor
        {
        }
    }
}
