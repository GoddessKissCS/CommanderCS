using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing game version information.
    /// </summary>
    public class DatabaseGameTableVersion : DatabaseTable<DatabaseVersionScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseGameTableVersion"/> class.
        /// </summary>
        public DatabaseGameTableVersion() : base("GameTableVersion")
        {
        }

        /// <summary>
        /// Inserts a new game version into the database.
        /// </summary>
        /// <param name="version">The version to insert.</param>
        /// <returns>The inserted game version.</returns>
        public DatabaseVersionScheme Insert(double version)
        {
            DatabaseVersionScheme dataInfo = new()
            {
                Version = version
            };

            DatabaseCollection.InsertOne(dataInfo);

            return dataInfo;
        }

        /// <summary>
        /// Retrieves the game version from the database.
        /// </summary>
        /// <returns>The game version.</returns>
        public DatabaseVersionScheme Get()
        {
            return DatabaseCollection.AsQueryable().FirstOrDefault();
        }
    }
}