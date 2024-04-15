using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing rotation banner data.
    /// </summary>
    public class DatabaseRotationBanner : DatabaseTable<AIScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRotationBanner"/> class with the specified table name.
        /// </summary>
        public DatabaseRotationBanner() : base("RotationBanner")
        {
        }
    }
}