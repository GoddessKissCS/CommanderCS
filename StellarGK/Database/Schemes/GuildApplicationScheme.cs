using MongoDB.Bson;

namespace StellarGK.Database.Schemes
{
    public class GuildApplicationScheme
    {
        public ObjectId Id { get; set; }
        public int GuildId { get; set; }
        public int Uno { get; set; }
    }
}