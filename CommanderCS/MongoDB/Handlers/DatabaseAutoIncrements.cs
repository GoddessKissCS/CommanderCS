using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseAutoIncrements : DatabaseTable<AIScheme>
    {
        public DatabaseAutoIncrements() : base("AutoIncrements")
        {
        }

        public int GetNextNumber(string name, int starting = 1000)
        {
            AIScheme AutoIncrement = DatabaseCollection.FindOneAndUpdate(Builders<AIScheme>.Filter.Eq("Name", name), Builders<AIScheme>.Update.SetOnInsert("Count", starting), new FindOneAndUpdateOptions<AIScheme> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            DatabaseCollection.UpdateOne(Builders<AIScheme>.Filter.Eq("Name", AutoIncrement.Name), Builders<AIScheme>.Update.Inc("Count", 1));
            return AutoIncrement.Count + 1;
        }
    }
}