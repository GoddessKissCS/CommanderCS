using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseRotationBanner : DatabaseTable<AIScheme>
    {
        public DatabaseRotationBanner() : base("RotationBanner")
        {
        }
    }
}