using MongoDB.Driver;
using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseDormitory : DatabaseTable<DormitoryScheme>
    {
        public DatabaseDormitory() : base("Dormitory") { }

        public DormitoryScheme Create(int id)
        {
            DormitoryScheme? tryUser = Collection.AsQueryable().Where(d => d.memberId == id).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            //TODO THIS
            DormitoryScheme user = new()
            {
                memberId = id,
                CostumeHead = new()
                {

                },
                DormitoryInfo = new()
                {
                    { "inven", 10 } // MEANS INVENTORY LIMIT
                },
                DormitoryResource = new()
                {
                    __dormitoryPoint = "10",
                    __ston = "10",
                    __elec = "10",
                    __wood = "10",
                },
                ItemAdvanced = new()
                {

                },
                CostumeBody = new()
                {

                },
                ItemNormal = new()
                {

                },
                ItemWallpaper = new()
                {

                }
            };

            Collection.InsertOne(user);

            return user;
        }

        public DormitoryScheme? FindByUid(int uid)
        {
            return Collection.AsQueryable().Where(d => d.memberId == uid).FirstOrDefault();
        }
        public DormitoryScheme? FindBySession(string session)
        {
            GameProfileScheme? user = DatabaseManager.GameProfile.FindBySession(session);

            var dormitory = FindByUid(user.MemberId);

            return dormitory;
        }

    }
}
