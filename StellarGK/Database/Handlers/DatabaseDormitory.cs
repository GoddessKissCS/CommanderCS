using MongoDB.Driver;
using StellarGK.Database.Schemes;

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
                    { "inven", 10 } // MEANS INVENTORY LIMIT
                },
                dormitoryResource = new()
                {
                    __dormitoryPoint = "10",
                    __ston = "10",
                    __elec = "10",
                    __wood = "10",
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

        public DormitoryScheme? FindByUid(int uid)
        {
            DormitoryScheme? user = collection.AsQueryable().Where(d => d.Id == uid).FirstOrDefault();
            return user;
        }
        public DormitoryScheme? FindBySession(string session)
        {
            GameProfileScheme? user = DatabaseManager.GameProfile.FindBySession(session);

            var dormitory = FindByUid(user.memberId);

            return dormitory;
        }

    }
}
