using StellarGK.Database.Handlers;

namespace StellarGK.Database
{
    public class DatabaseManager
    {
        public static DatabaseAutoIncrements AutoIncrements { get; } = new();
        public static DatabaseAccount Account { get; } = new();
        public static DatabaseDormitory Dormitory { get; } = new();
        public static DatabaseDeviceCode DeviceCode { get; } = new();
        public static DatabaseServer Server { get; } = new();
        public static DatabaseGuild Guild { get; } = new();
        public static DatabaseGameVersion GameVersionInfo { get; } = new();
        public static DatabaseGameTableVersion GameTableVersion { get; } = new();
        public static DatabaseGameProfile GameProfile { get; } = new();
        
        public static void FirstCreate()
        {
            GameVersionInfo.Create(1, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L0ZpbGVDRE4v", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);
            GameVersionInfo.Create(2, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L0ZpbGVDRE4v", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);
            GameVersionInfo.Create(3, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L0ZpbGVDRE4v", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);
            GameVersionInfo.Create(4, "1.066.12", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L0ZpbGVDRE4v", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQucGhw", false, false, false, false);

            GameTableVersion.Create(20220312000000);

            Server.Create(1, 140, "18-20", 1643673600, 0, 0);
            Server.Create(2, 140, "18-20", 1643673600, 0, 0);
            Server.Create(3, 140, "18-20", 1643673600, 0, 0);
            Server.Create(4, 140, "18-20", 1643673600, 0, 0);
        }

    }

}
