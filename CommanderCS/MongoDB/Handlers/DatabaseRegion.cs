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
        /// <param name="ChannelId">The unique identifier of the server.</param>
        /// <param name="ServerRegion">The region of the server.</param>
        /// <param name="MaxLevel">The maximum level of the server.</param>
        /// <param name="MaxStage">The maximum stage of the server.</param>
        /// <param name="openDateTime">The opening date of the server.</param>
        /// <param name="PlayerCount">The number of players on the server.</param>
        /// <param name="ServerCount">The total number of servers.</param>
        public void Insert(int ChannelId, string ServerRegion, int MaxLevel, string MaxStage, double openDateTime, int PlayerCount, int ServerCount)
        {
            RegionScheme versionInfo = new()
            {
                ChannelId = ChannelId,
                ServerRegion = ServerRegion,
                MaxLevel = MaxLevel,
                MaxStage = MaxStage,
                OpenDate = openDateTime,
                PlayerCount = PlayerCount,
                ServerCount = ServerCount,
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