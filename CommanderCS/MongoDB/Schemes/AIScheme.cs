using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents an AI scheme stored in the database.
    /// </summary>
    public class AIScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the AI scheme.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the AI scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the count associated with the AI scheme.
        /// </summary>
        public int Count { get; set; }
    }
}