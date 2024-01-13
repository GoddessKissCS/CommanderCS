using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseRaidRankList : DatabaseTable<GuildScheme>
    {
        public DatabaseRaidRankList() : base("RaidRankList")
        {
        }
    }
}