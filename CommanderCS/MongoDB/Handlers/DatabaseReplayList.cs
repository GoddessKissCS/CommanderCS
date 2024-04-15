using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing replay list data.
    /// </summary>
    public class DatabaseReplayList : DatabaseTable<GuildScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseReplayList"/> class with the specified table name.
        /// </summary>
        public DatabaseReplayList() : base("ReplayList")
        {
        }
    }
}