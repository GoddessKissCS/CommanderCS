using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing server information.
    /// </summary>
    public class DatabaseRegion : DatabaseTable<RegionScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRegion"/> class with the specified table name.
        /// </summary>
        public DatabaseRegion() : base("Region")
        {
        }

        /// <summary>
        /// Inserts server information into the database.
        /// </summary>
        /// <param name="id">The unique identifier of the server.</param>
        /// <param name="region">The region of the server.</param>
        /// <param name="maxlevel">The maximum level of the server.</param>
        /// <param name="maxstage">The maximum stage of the server.</param>
        /// <param name="openDt">The opening date of the server.</param>
        /// <param name="playercount">The number of players on the server.</param>
        /// <param name="servercount">The total number of servers.</param>
        public void Insert(int id, string region, int maxlevel, string maxstage, double openDt, int playercount, int servercount)
        {
            RegionScheme versionInfo = new()
            {
                ChannelId = id,
                ServerRegion = region,
                MaxLevel = maxlevel,
                MaxStage = maxstage,
                OpenDate = openDt,
                PlayerCount = playercount,
                ServerCount = servercount,
            };

            DatabaseCollection.InsertOne(versionInfo);
        }

        /// <summary>
        /// Retrieves server information based on the provided server ID.
        /// </summary>
        /// <param name="id">The unique identifier of the server.</param>
        /// <returns>The server information.</returns>
        public RegionScheme Get(int id)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.ChannelId == id).FirstOrDefault();
        }
    }
}