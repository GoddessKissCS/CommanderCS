using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseServer : DatabaseTable<ServerScheme>
    {
        public DatabaseServer() : base("Server")
        {


        }

        public void Insert(string ServerRegion, int PlayerCount, string Server)
        {
            ServerScheme server = new()
            {
                Region = ServerRegion,
                PlayerCount = PlayerCount,
                ServerName = Server,

            };

            DatabaseCollection.InsertOne(server);
        }

        public List<ServerScheme> GetAllFromRegion(string Region)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Region == Region).ToList();
        }

        public ServerScheme GetFromServerNameAndRegion(string Region, string ServerName) {
            return DatabaseCollection.AsQueryable().Where(c => c.Region == Region).FirstOrDefault(d => d.ServerName == ServerName);
        }

    }
}