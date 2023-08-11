using MongoDB.Driver;
using StellarGK.Database.Schemes;

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
                version = ver,
                cdn_url = cdn,
                game_url = game,
                chat_url = chat,
                fileCheck = fc,
                enableGoogleLogin = gglogin,
                showPolicy = policy,
                version_state = stat,
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
