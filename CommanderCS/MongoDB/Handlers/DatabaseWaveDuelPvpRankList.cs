using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseWaveDuelPvpRankList : DatabaseTable<GuildScheme>
    {
        public DatabaseWaveDuelPvpRankList() : base("WaveDuelPvpRankList")
        {
        }
    }
}