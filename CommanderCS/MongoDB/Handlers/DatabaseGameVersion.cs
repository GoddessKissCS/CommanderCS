using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing game version information.
    /// </summary>
    public class DatabaseGameVersion : DatabaseTable<GameVersionScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseGameVersion"/> class.
        /// </summary>
        public DatabaseGameVersion() : base("GameVersion")
        {
        }

        /// <summary>
        /// Inserts a new game version into the database.
        /// </summary>
        /// <param name="id">The channel ID.</param>
        /// <param name="ver">The version string.</param>
        /// <param name="cdn">The CDN URL.</param>
        /// <param name="game">The game URL.</param>
        /// <param name="chat">The chat URL.</param>
        /// <param name="gglogin">Whether Google login is enabled.</param>
        /// <param name="fc">Whether file check is enabled.</param>
        /// <param name="stat">The status of the version.</param>
        /// <param name="policy">Whether to show the policy.</param>
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
                // probably should add more "word lists"
                Word = new Dictionary<string, double>
                {
                    { "en", 0.1 }
                }
            };

            DatabaseCollection.InsertOne(versionInfo);
        }

        /// <summary>
        /// Retrieves the game version from the database.
        /// </summary>
        /// <param name="id">The channel ID.</param>
        /// <returns>The game version.</returns>
        public GameVersionScheme Get(int id)
        {
            return DatabaseCollection.AsQueryable().FirstOrDefault(d => d.ChannelId == id);
        }
    }
}