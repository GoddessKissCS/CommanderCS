using MongoDB.Driver;
using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseAutoIncrements : DatabaseTable<AIScheme>
    {
        public DatabaseAutoIncrements() : base("AutoIncrements") { }

        public int GetNextNumber(string name, int starting = 100)
        {
            AIScheme AutoIncrement = Collection.FindOneAndUpdate(Builders<AIScheme>.Filter.Eq("Name", name), Builders<AIScheme>.Update.SetOnInsert("Count", starting), new FindOneAndUpdateOptions<AIScheme> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            Collection.UpdateOne(Builders<AIScheme>.Filter.Eq("Name", AutoIncrement.Name), Builders<AIScheme>.Update.Inc("Count", 1));
            return AutoIncrement.Count + 1;
        }
    }
}
