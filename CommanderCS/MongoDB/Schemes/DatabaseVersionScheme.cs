using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a database version scheme.
    /// </summary>
    public class DatabaseVersionScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the database version scheme.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the version of the database.
        /// </summary>
        public double Version { get; set; }
    }
}