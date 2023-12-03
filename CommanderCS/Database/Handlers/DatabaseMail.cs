using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseMail : DatabaseTable<GuildScheme>
    {
        public DatabaseMail() : base("Mail") { }
    }
}