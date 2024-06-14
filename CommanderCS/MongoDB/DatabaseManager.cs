using CommanderCS.MongoDB.Handlers;

namespace CommanderCS.MongoDB
{
    /// <summary>
    /// Manages the database interactions for various entities.
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// Gets the database manager for auto-increments.
        /// </summary>
        public static DatabaseAutoIncrements AutoIncrements { get; } = new();

        /// <summary>
        /// Gets the database manager for user accounts.
        /// </summary>
        public static DatabaseAccount Account { get; } = new();

        /// <summary>
        /// Gets the database manager for dormitory data.
        /// </summary>
        public static DatabaseDormitory Dormitory { get; } = new();

        /// <summary>
        /// Gets the database manager for device codes.
        /// </summary>
        public static DatabaseDeviceCode DeviceCode { get; } = new();

        /// <summary>
        /// Gets the database manager for servers.
        /// </summary>
        public static DatabaseServer Server { get; } = new();

        /// <summary>
        /// Gets the database manager for guilds.
        /// </summary>
        public static DatabaseGuild Guild { get; } = new();

        /// <summary>
        /// Gets the database manager for guild applications.
        /// </summary>
        public static DatabaseGuildApplication GuildApplication { get; } = new();

        /// <summary>
        /// Gets the database manager for game version information.
        /// </summary>
        public static DatabaseGameVersion GameVersionInfo { get; } = new();

        /// <summary>
        /// Gets the database manager for game table version.
        /// </summary>
        public static DatabaseGameTableVersion GameTableVersion { get; } = new();

        /// <summary>
        /// Gets the database manager for game profiles.
        /// </summary>
        public static DatabaseGameProfile GameProfile { get; } = new();

        /// <summary>
        /// Initializes the database manager.
        /// </summary>
        public static void Init()
        {
            // Check if the game table version matches the current version

            var gametables = GameTableVersion.Get();

            if (gametables != null)
            {
                if(gametables.Version == 20220312000000)
                {
                    return;
                }
            }

            // Initialize game version information
            GameVersionInfo.Insert(1, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjgwOjUwMDAvRmlsZUNETi8=", "aHR0cDovLzE5Mi4xNjguMTc4LjgwOjUwMDAvY2hlY2tEYXRhLnBocA==", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);
            GameVersionInfo.Insert(2, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L0ZpbGVDRE4v", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);

            // Initialize game table version
            GameTableVersion.Insert(20220312000000);

            // Initialize servers
            Server.Insert(1, "Korea", 140, "18-20", 1643673600, 0, 0);
            Server.Insert(2, "Global", 140, "18-20", 1643673600, 0, 0);
        }
    }
}