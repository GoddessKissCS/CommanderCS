using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseMail : DatabaseTable<GuildScheme>
    {
        public DatabaseMail() : base("Mail") { }
    }
}