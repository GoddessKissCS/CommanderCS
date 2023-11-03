using MongoDB.Driver;
using StellarGK.Database.Schemes;

namespace StellarGK.Database.Handlers
{
    public class DatabaseDormitory : DatabaseTable<DormitoryScheme>
    {
        public DatabaseDormitory() : base("Dormitory")
        {
        }

        public void Create(int id)
        {
            DormitoryScheme? tryUser = Collection.AsQueryable().Where(d => d.Uno == id).FirstOrDefault();
            if (tryUser != null) { return; }

            //TODO THIS
            DormitoryScheme user = new()
            {
                Uno = id,
                CostumeHead = new()
                {
                },
                DormitoryInfo = new()
                {
                    { "inven", 100 } // MEANS INVENTORY LIMIT
                },
                DormitoryResource = new()
                {
                    __dormitoryPoint = "0",
                    __ston = "0",
                    __elec = "0",
                    __wood = "0",
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
        }

        public DormitoryScheme? FindByUno(int uid)
        {
            return Collection.AsQueryable().Where(d => d.Uno == uid).FirstOrDefault();
        }

        public DormitoryScheme? FindBySession(string session)
        {
            GameProfileScheme? user = DatabaseManager.GameProfile.FindBySession(session);

            int uno = int.Parse(user.Uno);

            return FindByUno(uno);
        }
    }
}