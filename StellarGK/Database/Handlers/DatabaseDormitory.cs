using MongoDB.Driver;
using StellarGK.Database.Models;

namespace StellarGK.Database.Handlers
{
    public class DatabaseDormitory : DatabaseTable<DormitoryScheme>
    {
        public DatabaseDormitory() : base("Dormitory") { }

        public DormitoryScheme Create(int id)
        {
            DormitoryScheme? tryUser = collection.AsQueryable().Where(d => d.Id == id).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            //TODO THIS
            DormitoryScheme user = new()
            {
                Id = id,
                costumeHead = new()
                {

                },
                dormitoryInfo = new()
                {
                    { "inven", 999 } // MEANS INVENTORY LIMIT
                },
                dormitoryResource = new()
                {
                    __dormitoryPoint = "1",
                    __ston = "1",
                    __elec = "1",
                    __wood = "1",
                },
                itemAdvanced = new()
                {

                },
                costumeBody = new()
                {

                },
                itemNormal = new()
                {

                },
                itemWallpaper = new()
                {

                }
            };

            collection.InsertOne(user);

            return user;
        }

        public DormitoryScheme FindByName(string name)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.name == name).FirstOrDefault();

            var dormitory = FindByUid(user.Id);

            return dormitory;
        }
        public DormitoryScheme? FindByToken(string token)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.token == token).FirstOrDefault();

            var dormitory = FindByUid(user.Id);

            return dormitory;
        }
        public DormitoryScheme? FindByUid(int uid)
        {
            DormitoryScheme? user = collection.AsQueryable().Where(d => d.Id == uid).FirstOrDefault();
            return user;
        }
        public DormitoryScheme? FindBySession(string session)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.session == session).FirstOrDefault();

            var dormitory = FindByUid(user.Id);

            return dormitory;
        }

    }
}
