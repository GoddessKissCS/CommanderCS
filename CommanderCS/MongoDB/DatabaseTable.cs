using MongoDB.Driver;

namespace CommanderCS.MongoDB
{
    /// <summary>
    /// Represents an abstract class for a database table.
    /// </summary>
    /// <typeparam name="T">The type of the documents stored in the database table.</typeparam>
    public abstract class DatabaseTable<T>
    {
        /// <summary>
        /// The MongoDB client instance.
        /// </summary>
        protected static MongoClient MongoClient = new("mongodb://127.0.0.1:27017/GoddessKiss");

        /// <summary>
        /// The MongoDB database instance.
        /// </summary>
        protected static readonly IMongoDatabase Database = MongoClient.GetDatabase("GoddessKiss");

        /// <summary>
        /// The MongoDB collection for the specified document type.
        /// </summary>
        protected static IMongoCollection<T> DatabaseCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseTable{T}"/> class.
        /// </summary>
        /// <param name="collectionName">The name of the collection in the database.</param>
        protected DatabaseTable(string collectionName)
        {
            DatabaseCollection = Database.GetCollection<T>(collectionName);
        }
    }
}