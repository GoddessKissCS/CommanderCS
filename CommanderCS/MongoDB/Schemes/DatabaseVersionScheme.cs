using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class DatabaseVersionScheme
    {
        public ObjectId Id { get; set; }
        public double Version { get; set; }
    }
}