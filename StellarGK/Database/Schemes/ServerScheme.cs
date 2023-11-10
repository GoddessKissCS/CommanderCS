using MongoDB.Bson;

namespace StellarGK.Database.Schemes
{
    public class ServerScheme
    {
        public ObjectId Id { get; set; }
        public int ChannelId { get; set; }
        public string ServerRegion { get; set; }
        public double OpenDate { get; set; }
        public int MaxLevel { get; set; }
        public string MaxStage { get; set; }
        public int PlayerCount { get; set; }
        public int ServerCount { get; set; }
    }
}