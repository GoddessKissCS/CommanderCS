using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for auto-increments.
    /// </summary>
    public class DatabaseAutoIncrements : DatabaseTable<AIScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseAutoIncrements"/> class.
        /// </summary>
        public DatabaseAutoIncrements() : base("AutoIncrements")
        {
        }

        /// <summary>
        /// Gets the next number in the auto-increment sequence for the specified counter name.
        /// </summary>
        /// <param name="name">The name of the counter.</param>
        /// <param name="starting">The starting value of the counter if it doesn't exist (default is 1000).</param>
        /// <returns>The next number in the auto-increment sequence.</returns>
        public int GetNextNumber(string name, int starting = 1000)
        {
            AIScheme AutoIncrement = DatabaseCollection.FindOneAndUpdate(Builders<AIScheme>.Filter.Eq("Name", name), Builders<AIScheme>.Update.SetOnInsert("Count", starting), new FindOneAndUpdateOptions<AIScheme> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            DatabaseCollection.UpdateOne(Builders<AIScheme>.Filter.Eq("Name", AutoIncrement.Name), Builders<AIScheme>.Update.Inc("Count", 1));
            return AutoIncrement.Count + 1;
        }
    }
}