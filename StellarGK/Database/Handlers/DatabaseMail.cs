using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseMail : DatabaseTable<GuildScheme>
    {
        public DatabaseMail() : base("Mail") { }
    }
}