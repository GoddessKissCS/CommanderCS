using MongoDB.Bson;

namespace StellarGK.Database.Schemes
{
    public class DatabaseVersionScheme
    {
        public ObjectId Id { get; set; }
        public double version { get; set; }
    }
}
