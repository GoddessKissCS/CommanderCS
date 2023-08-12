using MongoDB.Bson;

namespace StellarGK.Database.Schemes
{
    public class GuildApplicationScheme
    {
        public ObjectId Id { get; set; }
        public int guildId { get; set; }
        public string uno { get; set; }
    }
}
