using MongoDB.Driver;
using StellarGK.Database.Models;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGameVersion : DatabaseTable<GameVersionScheme>
    {
        public DatabaseGameVersion() : base("GameVersion") { }

        public GameVersionScheme Create(int id, string ver, string cdn, string game, string chat, bool gglogin, bool fc, bool stat, bool policy)
        {

            GameVersionScheme versionInfo = new()
            {
                Id = id,
                ver = ver,
                cdn = cdn,
                game = game,
                chat = chat,
                fc = fc,
                gglogin = gglogin,
                policy = policy,
                stat = stat,
                word = new()
                {
                    { "en", 1 }
                }
            };

            collection.InsertOne(versionInfo);

            return versionInfo;
        }

        public GameVersionScheme Get(int id)
        {
            return collection.AsQueryable().Where(d => d.Id == id).FirstOrDefault();
        }
    }
}
