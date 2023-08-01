using MongoDB.Driver;
using StellarGK.Database.Models;

namespace StellarGK.Database.Handlers
{
    public class DatabaseServer : DatabaseTable<ServerScheme>
    {
        public DatabaseServer() : base("Servers") { }

        public ServerScheme Create(int id, int maxlevel, string maxstage, double openDt, int playercount, int servercount)
        {
            ServerScheme versionInfo = new()
            {
                Id = id,
                maxLevel = maxlevel,
                maxStage = maxstage,
                openDateTime = openDt,
                playerCount = playercount,
                serverCount = servercount,
            };

            collection.InsertOne(versionInfo);

            return versionInfo;
        }

        public ServerScheme Get(int id)
        {
            ServerScheme? server = collection.AsQueryable().Where(d => d.Id == id).FirstOrDefault();

            return server;
        }
    }



}
