using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a daily bonus scheme stored in the database.
    /// </summary>
    public class DailyBonusScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the daily bonus scheme.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier associated with the user.
        /// </summary>
        public string Uno { get; set; }

        /// <summary>
        /// Gets or sets the day of the daily bonus.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the daily bonus has been received.
        /// </summary>
        public int Received { get; set; }
    }
}