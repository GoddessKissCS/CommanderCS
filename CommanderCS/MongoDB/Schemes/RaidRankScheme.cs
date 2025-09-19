using MongoDB.Bson;
using Newtonsoft.Json;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a Raid rank list scheme.
    /// </summary>
    public class RaidRankScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public ObjectId Id { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public string _name { get; set; }
        public string thumb { get; set; }
        public int score { get; set; }
        public int grade { get; set; }
        public int rank { get; set; }
        public int time { get; set; }
        public string guildName { get; set; }
        public int guildServer { get; set; }
    }
}