using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseNotice : DatabaseTable<AIScheme>
    {
        public DatabaseNotice() : base("Notice")
        {
        }
    }
}