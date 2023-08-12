using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseDailyBonus : DatabaseTable<GuildScheme>
    {
        public DatabaseDailyBonus() : base("DailyBonus") { }
    }
}