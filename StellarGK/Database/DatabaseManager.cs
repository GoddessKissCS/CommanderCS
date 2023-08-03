using StellarGK.Database.Handlers;

namespace StellarGK.Database
{
    public class DatabaseManager
    {
        public static DatabaseAccount Account { get; } = new();
        public static DatabaseBattleStatistics BattleStatistics { get; } = new();
        public static DatabaseDormitory Dormitory { get; } = new();
        public static DatabaseDeviceCode DeviceCode { get; } = new();
        public static DatabaseResources Resources { get; } = new();
        public static DatabaseServer Server { get; } = new();
        public static DatabaseGuild Guild { get; } = new();
        public static DatabaseGameVersion GameVersionInfo { get; } = new();
        public static DatabaseGameTableVersion GameTableVersion { get; } = new();
        public static DatabaseGameData GameData { get; } = new();
        public static void FirstCreate()
        {
            GameVersionInfo.Create(1, "1.066.12", "aGh0dHA6Ly8xOTIuMTY4LjE3OC4yOS9jaGF0LnBocA==", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQv", false, false, false, false);
            GameVersionInfo.Create(2, "1.066.12", "aGh0dHA6Ly8xOTIuMTY4LjE3OC4yOS9jaGF0LnBocA==", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQv", false, false, false, false);
            GameVersionInfo.Create(3, "1.066.12", "aGh0dHA6Ly8xOTIuMTY4LjE3OC4yOS9jaGF0LnBocA==", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQv", false, false, false, false);
            GameVersionInfo.Create(4, "1.066.12", "aGh0dHA6Ly8xOTIuMTY4LjE3OC4yOS9jaGF0LnBocA==", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoZWNrRGF0YS5waHA=", "aHR0cDovLzE5Mi4xNjguMTc4LjI5L2NoYXQv", false, false, false, false);

            GameTableVersion.Create(20220312000000);

            Server.Create(1, 140, "18-20", 1643673600, 0, 0);
            Server.Create(2, 140, "18-20", 1643673600, 0, 0);
            Server.Create(3, 140, "18-20", 1643673600, 0, 0);
            Server.Create(4, 140, "18-20", 1643673600, 0, 0);
        }

        public static void CreateUser(int memberId)
        {
            BattleStatistics.Create(memberId);
            Resources.Create(memberId);
            Dormitory.Create(memberId);
            GameData.Create(memberId);
        }

    }

}
