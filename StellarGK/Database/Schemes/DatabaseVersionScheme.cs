using MongoDB.Bson;

namespace CommanderCS.Database.Schemes
{
    public class DatabaseVersionScheme
    {
        public ObjectId Id { get; set; }
        public double Version { get; set; }
    }
}