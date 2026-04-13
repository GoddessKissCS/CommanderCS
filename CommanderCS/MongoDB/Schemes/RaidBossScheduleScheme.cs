using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Persists the weekly raid boss rotation.
    /// Each document represents one day-of-week slot and the bosses active on that day.
    /// </summary>
    public class RaidBossScheduleScheme
    {
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Day of the week this entry applies to (0 = Sunday … 6 = Saturday),
        /// matching <see cref="DayOfWeek"/> cast to int.
        /// </summary>
        public int DayOfWeek { get; set; }

        /// <summary>
        /// Bosses active on this day.
        /// Key = boss id (string, as the client expects), Value = difficulty level.
        /// e.g. { "1", 0 } means boss 1 at difficulty 0.
        /// </summary>
        public Dictionary<string, int> Bosses { get; set; } = [];
    }
}
