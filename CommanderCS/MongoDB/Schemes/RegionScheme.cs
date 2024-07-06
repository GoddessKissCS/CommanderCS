using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a server scheme.
    /// </summary>
    public class RegionScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the channel ID.
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// Gets or sets the server region.
        /// </summary>
        public string ServerRegion { get; set; }

        /// <summary>
        /// Gets or sets the open date.
        /// </summary>
        public double OpenDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum level.
        /// </summary>
        public int MaxLevel { get; set; }

        /// <summary>
        /// Gets or sets the maximum stage.
        /// </summary>
        public string MaxStage { get; set; }

        /// <summary>
        /// Gets or sets the player count.
        /// </summary>
        public int PlayerCount { get; set; }

        /// <summary>
        /// Gets or sets the server count.
        /// </summary>
        public int ServerCount { get; set; }
    }
}