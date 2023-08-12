using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseRaidRankList : DatabaseTable<GuildScheme>
    {
        public DatabaseRaidRankList() : base("RaidRankList") { }
    }
}