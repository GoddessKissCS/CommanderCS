using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for dormitory information.
    /// </summary>
    public class DatabaseDormitory : DatabaseTable<DormitoryScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseDormitory"/> class.
        /// </summary>
        public DatabaseDormitory() : base(collectionName: "Dormitory")
        {
        }

        /// <summary>
        /// Creates dormitory information for the specified ID if it does not already exist.
        /// </summary>
        /// <param name="id">The ID for which to create dormitory information.</param>
        public void Create(int id)
        {
            DormitoryScheme? tryUser = DatabaseCollection.AsQueryable().Where(d => d.Uno == id).FirstOrDefault();
            if (tryUser is not null) { return; }

            //TODO
            DormitoryScheme user = new()
            {
                Uno = id,
                CostumeHead = [],
                DormitoryInfo = new()
                {
                    { "inven", 100 } // Represents inventory limit
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

        /// <summary>
        /// Finds dormitory information by the specified ID.
        /// </summary>
        /// <param name="uid">The ID associated with the dormitory information.</param>
        /// <returns>The dormitory information associated with the ID, or null if not found.</returns>
        public DormitoryScheme? FindByUno(int uid)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Uno == uid).FirstOrDefault();
        }

        /// <summary>
        /// Finds dormitory information by the session associated with a user's game profile.
        /// </summary>
        /// <param name="session">The session associated with the user's game profile.</param>
        /// <returns>The dormitory information associated with the user's game profile session, or null if not found.</returns>
        public DormitoryScheme? FindBySession(string session)
        {
            GameProfileScheme? user = DatabaseManager.GameProfile.FindBySession(session);
            return FindByUno(user.Uno);
        }
    }
}