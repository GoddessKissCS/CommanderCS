using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseReplayList : DatabaseTable<GuildScheme>
    {
        public DatabaseReplayList() : base("ReplayList")
        {
        }
    }
}