using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseReplayList : DatabaseTable<GuildScheme>
    {
        public DatabaseReplayList() : base("ReplayList")
        {
        }
    }
}