using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseGuildRankingList : DatabaseTable<GuildScheme>
    {
        public DatabaseGuildRankingList() : base("GuildRankingList")
        {
        }
    }
}
