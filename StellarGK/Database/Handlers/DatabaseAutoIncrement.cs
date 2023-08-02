using MongoDB.Driver;
using StellarGK.Database.Models;

namespace StellarGK.Database.Handlers
{
    public class DatabaseAutoIncrement : DatabaseTable<AIScheme>
    {
        public DatabaseAutoIncrement() : base("AutoIncrements") { }

        public static int GetNextNumber(string name, int starting = 100)
        {
            AIScheme AutoIncrement = collection.FindOneAndUpdate(Builders<AIScheme>.Filter.Eq("Name", name), Builders<AIScheme>.Update.SetOnInsert("Count", starting), new FindOneAndUpdateOptions<AIScheme> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            collection.UpdateOne(Builders<AIScheme>.Filter.Eq("Name", AutoIncrement.Name), Builders<AIScheme>.Update.Inc("Count", 1));
            return AutoIncrement.Count + 1;
        }
    }
}
