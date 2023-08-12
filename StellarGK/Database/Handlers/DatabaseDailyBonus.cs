using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseDailyBonus : DatabaseTable<GuildScheme>
    {
        public DatabaseDailyBonus() : base("DailyBonus") { }
    }
}