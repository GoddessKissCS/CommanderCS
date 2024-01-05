using CommanderCS.Database.Handlers;

namespace CommanderCS.Database
{
    public class DatabaseManager
    {
        public static DatabaseAutoIncrements AutoIncrements { get; } = new();
        public static DatabaseAccount Account { get; } = new();
        public static DatabaseDormitory Dormitory { get; } = new();
        public static DatabaseDeviceCode DeviceCode { get; } = new();
        public static DatabaseServer Server { get; } = new();
        public static DatabaseGuild Guild { get; } = new();
        public static DatabaseGuildApplication GuildApplication { get; } = new();
        public static DatabaseGameVersion GameVersionInfo { get; } = new();
        public static DatabaseGameTableVersion GameTableVersion { get; } = new();
        public static DatabaseGameProfile GameProfile { get; } = new();

        public static void Init()
        {
            // will be changed in future ofc
            if (GameTableVersion.Get().Version == 20220312000000)
            {
                return;
            }

            GameVersionInfo.Insert(1, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L0ZpbGVDRE4v", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);
            GameVersionInfo.Insert(2, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L0ZpbGVDRE4v", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);

            GameTableVersion.Insert(20220312000000);

            Server.Insert(1, "Korea", 140, "18-20", 1643673600, 0, 0);
            Server.Insert(2, "Global", 140, "18-20", 1643673600, 0, 0);
        }
    }
}