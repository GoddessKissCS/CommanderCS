using MongoDB.Driver;
using StellarGK.Database.Models;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGameTableVersion : DatabaseTable<DatabaseVersionScheme>
    {
        public DatabaseGameTableVersion() : base("GameTableVersion") { }

        public DatabaseVersionScheme Create(double version)
        {
            DatabaseVersionScheme dataInfo = new()
            {
                ver = version
            };

            collection.InsertOne(dataInfo);

            return dataInfo;
        }

        public DatabaseVersionScheme Get()
        {
            return collection.AsQueryable().FirstOrDefault();
        }
    }
}
