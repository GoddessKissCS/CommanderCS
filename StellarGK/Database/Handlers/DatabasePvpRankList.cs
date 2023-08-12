using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabasePvpRankList : DatabaseTable<GuildScheme>
    {
        public DatabasePvpRankList() : base("PvpRankList") { }
    }
}