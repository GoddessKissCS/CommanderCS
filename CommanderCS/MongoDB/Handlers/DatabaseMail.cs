using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseMail : DatabaseTable<GuildScheme>
    {
        public DatabaseMail() : base("Mail")
        {
        }
    }
}