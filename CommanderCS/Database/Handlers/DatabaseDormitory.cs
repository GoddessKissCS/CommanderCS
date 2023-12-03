using MongoDB.Driver;
using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseDormitory : DatabaseTable<DormitoryScheme>
    {
        public DatabaseDormitory() : base("Dormitory") { }

        public void Create(int id)
        {

            DormitoryScheme? tryUser = DatabaseCollection.AsQueryable().Where(d => d.Uno == id).FirstOrDefault();
            if (tryUser != null) { return; }

            //TODO THIS
            DormitoryScheme user = new()
            {
                Uno = id,
                CostumeHead = [],
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
                ItemAdvanced = [],
                CostumeBody = [],
                ItemNormal = [],
                ItemWallpaper = []
            };

            DatabaseCollection.InsertOne(user);
        }

        public DormitoryScheme? FindByUno(int uid)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Uno == uid).FirstOrDefault();
        }

        public DormitoryScheme? FindBySession(string session)
        {
            GameProfileScheme? user = DatabaseManager.GameProfile.FindBySession(session);

            return FindByUno(user.Uno);
        }
    }
}