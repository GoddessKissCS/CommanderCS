using MongoDB.Driver;

namespace CommanderCS.Database
{
    public abstract class DatabaseTable<T>
    {
        protected static MongoClient MongoClient = new("mongodb://127.0.0.1:27017/GoddessKiss");
        protected static readonly IMongoDatabase Database = MongoClient.GetDatabase("GoddessKiss");

        protected static IMongoCollection<T> DatabaseCollection;

        protected DatabaseTable(string collectionName)
        {
            DatabaseCollection = Database.GetCollection<T>(collectionName);
        }
    }
}