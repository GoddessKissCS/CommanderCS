using MongoDB.Bson;

namespace CommanderCS.Database.Schemes
{
    public class AIScheme
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}