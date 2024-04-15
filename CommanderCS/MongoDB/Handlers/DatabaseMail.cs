using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing mail data.
    /// </summary>
    public class DatabaseMail : DatabaseTable<GuildScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseMail"/> class with the specified table name.
        /// </summary>
        public DatabaseMail() : base("Mail")
        {
        }
    }
}