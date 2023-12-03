using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabasePvpRankList : DatabaseTable<GuildScheme>
    {
        public DatabasePvpRankList() : base("PvpRankList") { }
    }
}