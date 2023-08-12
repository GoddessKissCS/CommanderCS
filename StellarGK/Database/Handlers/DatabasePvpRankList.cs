using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabasePvpRankList : DatabaseTable<GuildScheme>
    {
        public DatabasePvpRankList() : base("PvpRankList") { }
    }
}