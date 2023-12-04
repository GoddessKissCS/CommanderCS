using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseRaidRankList : DatabaseTable<GuildScheme>
    {
        public DatabaseRaidRankList() : base("RaidRankList")
        {
        }
    }
}