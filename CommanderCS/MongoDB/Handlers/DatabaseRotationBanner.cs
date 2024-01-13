using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseRotationBanner : DatabaseTable<AIScheme>
    {
        public DatabaseRotationBanner() : base("RotationBanner")
        {
        }
    }
}