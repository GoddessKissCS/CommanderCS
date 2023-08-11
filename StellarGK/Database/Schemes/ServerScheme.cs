using MongoDB.Bson;

namespace StellarGK.Database.Schemes
{
    public class ServerScheme
    {
        public ObjectId Id { get; set; }
        public int channelId { get; set; }
        public double openDate { get; set; }
        public int maxLevel { get; set; }
        public string maxStage { get; set; }
        public int playerCount { get; set; }
        public int serverCount { get; set; }
    }
}
