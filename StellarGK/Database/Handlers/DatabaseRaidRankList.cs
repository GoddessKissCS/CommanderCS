using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseRaidRankList : DatabaseTable<GuildScheme>
    {
        public DatabaseRaidRankList() : base("RaidRankList")
        {
        }
    }
}