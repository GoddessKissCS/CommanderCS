using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseReplayList : DatabaseTable<GuildScheme>
    {
        public DatabaseReplayList() : base("ReplayList")
        {
        }
    }
}