using MongoDB.Driver;
using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseServer : DatabaseTable<ServerScheme>
    {
        public DatabaseServer() : base("Server")
        {
        }

        public void Insert(int id, string region, int maxlevel, string maxstage, double openDt, int playercount, int servercount)
        {
            ServerScheme versionInfo = new()
            {
                ChannelId = id,
                ServerRegion = region,
                MaxLevel = maxlevel,
                MaxStage = maxstage,
                OpenDate = openDt,
                PlayerCount = playercount,
                ServerCount = servercount,
            };

            DatabaseCollection.InsertOne(versionInfo);
        }

        public ServerScheme Get(int id) => DatabaseCollection.AsQueryable().Where(d => d.ChannelId == id).FirstOrDefault();
    }
}