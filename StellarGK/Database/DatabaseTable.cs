using MongoDB.Driver;

namespace StellarGK.Database
{
    public abstract class DatabaseTable<T>
    {
        protected static MongoClient MongoClient = new("mongodb://127.0.0.1:27017/goddesskiss");
        protected static readonly IMongoDatabase Database = MongoClient.GetDatabase("goddesskiss");

        protected static IMongoCollection<T> Collection;

        protected DatabaseTable(string collectionName)
        {
            Collection = Database.GetCollection<T>(collectionName);
        }

    }
}
