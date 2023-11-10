using MongoDB.Driver;
using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseServer : DatabaseTable<ServerScheme>
    {
        public DatabaseServer() : base("Servers")
        {
        }

        public ServerScheme Insert(int id, int maxlevel, string maxstage, double openDt, int playercount, int servercount)
        {
            ServerScheme versionInfo = new()
            {
                ChannelId = id,
                MaxLevel = maxlevel,
                MaxStage = maxstage,
                OpenDate = openDt,
                PlayerCount = playercount,
                ServerCount = servercount,
            };

            Collection.InsertOne(versionInfo);

            return versionInfo;
        }

        public ServerScheme Get(int id) => Collection.AsQueryable().Where(d => d.ChannelId == id).FirstOrDefault();
    }
}