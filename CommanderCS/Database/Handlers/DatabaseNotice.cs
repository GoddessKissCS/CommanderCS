using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseNotice : DatabaseTable<AIScheme>
    {
        public DatabaseNotice() : base("Notice") { }
    }
}