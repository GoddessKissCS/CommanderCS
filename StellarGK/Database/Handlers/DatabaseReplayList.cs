using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseReplayList : DatabaseTable<GuildScheme>
    {
        public DatabaseReplayList() : base("ReplayList") { }
    }
}