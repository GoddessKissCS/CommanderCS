using MongoDB.Driver;
using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseGameVersion : DatabaseTable<GameVersionScheme>
    {
        public DatabaseGameVersion() : base("GameVersion")
        {
        }

        public void Insert(int id, string ver, string cdn, string game, string chat, bool gglogin, bool fc, bool stat, bool policy)
        {
            GameVersionScheme versionInfo = new()
            {
                ChannelId = id,
                Version = ver,
                Cdn_Url = cdn,
                Game_Url = game,
                Chat_Url = chat,
                fileCheck = fc,
                enableGoogleLogin = gglogin,
                showPolicy = policy,
                Version_State = stat,
                Word = new()
                {
                    { "en", 1 }
                }
            };

            DatabaseCollection.InsertOne(versionInfo);
        }

        public GameVersionScheme Get(int id)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.ChannelId == id).FirstOrDefault();
        }
    }
}