using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseRotationBanner : DatabaseTable<AIScheme>
    {
        public DatabaseRotationBanner() : base("RotationBanner")
        {
        }
    }
}