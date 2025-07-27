using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class ServerScheme
    {
        public ObjectId Id { get; set; }
        public string Region { get; set; }
        public string ServerName { get; set; }
        public int PlayerCount {  get; set; }
    }
}
