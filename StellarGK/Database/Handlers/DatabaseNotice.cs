using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseNotice : DatabaseTable<AIScheme>
    {
        public DatabaseNotice() : base("Notice")
        {
        }
    }
}