using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class ConquestMatchingScheme
    {

        public ObjectId Id { get; set; }
        public int GuildId { get; set; }
        public int Level { get; set; }
        public int Count { get; set; }
        public int World { get; set; }
        public int Emblem { get; set; }
        public string Name { get; set; }
    }
}
