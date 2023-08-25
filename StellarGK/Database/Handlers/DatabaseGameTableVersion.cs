using MongoDB.Driver;
using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGameTableVersion : DatabaseTable<DatabaseVersionScheme>
    {
        public DatabaseGameTableVersion() : base("GameTableVersion") { }

        public DatabaseVersionScheme Create(double version)
        {
            DatabaseVersionScheme dataInfo = new()
            {
                Version = version
            };

            Collection.InsertOne(dataInfo);

            return dataInfo;
        }

        public DatabaseVersionScheme Get()
        {
            return Collection.AsQueryable().FirstOrDefault();
        }
    }
}
