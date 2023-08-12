using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGuildApplication : DatabaseTable<GuildScheme>
    {
        public DatabaseGuildApplication() : base("GuildApplications") { }
    }
}