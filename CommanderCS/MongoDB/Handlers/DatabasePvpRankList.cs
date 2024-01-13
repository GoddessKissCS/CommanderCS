using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabasePvpRankList : DatabaseTable<GuildScheme>
    {
        public DatabasePvpRankList() : base("PvpRankList")
        {
        }
    }
}