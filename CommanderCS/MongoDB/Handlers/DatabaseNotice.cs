using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing notice data.
    /// </summary>
    public class DatabaseNotice : DatabaseTable<AIScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseNotice"/> class with the specified table name.
        /// </summary>
        public DatabaseNotice() : base("Notice")
        {
        }
    }
}