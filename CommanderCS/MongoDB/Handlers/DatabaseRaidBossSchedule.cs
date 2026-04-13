using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Manages the raid boss weekly rotation stored in MongoDB.
    ///
    /// The schedule is seeded once during <see cref="DatabaseManager.Init"/> and never
    /// needs to be touched again unless you want to change which boss appears on which day.
    /// To change the rotation just edit the <see cref="DefaultSchedule"/> table below and
    /// call <see cref="Reseed"/> (or drop the collection and restart the server).
    /// </summary>
    public class DatabaseRaidBossSchedule : DatabaseTable<RaidBossScheduleScheme>
    {
        public DatabaseRaidBossSchedule() : base("RaidBossSchedule") { }

        // -----------------------------------------------------------------------
        // Rotation definition — edit this table to change the weekly schedule.
        // Key   = DayOfWeek (0 Sunday … 6 Saturday)
        // Value = boss id that is active that day (difficulty is unused; endTime
        //         is computed dynamically per day in GetBossDataForUpcomingDays).
        // -----------------------------------------------------------------------
        private static readonly Dictionary<int, List<string>> DefaultSchedule = new()
        {
            // Sunday
            { 0, ["2"] },
            // Monday
            { 1, ["3"] },
            // Tuesday
            { 2, ["1"] },
            // Wednesday
            { 3, ["2"] },
            // Thursday
            { 4, ["1"] },
            // Friday
            { 5, ["3"] },
            // Saturday
            { 6, ["1"] },
        };

        /// <summary>
        /// Seeds the default schedule if the collection is empty.
        /// Called once from <see cref="DatabaseManager.Init"/>.
        /// </summary>
        public void SeedIfEmpty()
        {
            if (DatabaseCollection.CountDocuments(FilterDefinition<RaidBossScheduleScheme>.Empty) > 0)
                return;

            Reseed();
        }

        /// <summary>
        /// Drops all existing schedule entries and re-inserts from <see cref="DefaultSchedule"/>.
        /// Useful if you have changed the schedule table and want to apply it without wiping the DB.
        /// </summary>
        public void Reseed()
        {
            DatabaseCollection.DeleteMany(FilterDefinition<RaidBossScheduleScheme>.Empty);

            var documents = DefaultSchedule.Select(entry => new RaidBossScheduleScheme
            {
                DayOfWeek = entry.Key,
                // Store boss ids only; value (endTime) is computed at query time.
                Bosses = entry.Value.ToDictionary(bossId => bossId, _ => 0),
            });

            DatabaseCollection.InsertMany(documents);
        }

        /// <summary>
        /// Returns boss data for today and the next <paramref name="days"/> - 1 days,
        /// flattened into a single list matching the wire format the client expects for <c>bossData</c>.
        ///
        /// The value for each boss entry is the number of seconds until that day's boss expires
        /// (midnight UTC of that day), so each successive day is ~86 400 seconds higher than the last —
        /// mirroring how <c>endTime</c> works in the response info block.
        /// </summary>
        public List<Dictionary<string, int>> GetBossDataForUpcomingDays(int days = 3)
        {
            var result = new List<Dictionary<string, int>>();
            var todayMidnightUtc = DateTime.UtcNow.Date;

            for (int i = 0; i < days; i++)
            {
                DayOfWeek day = (DayOfWeek)(((int)DateTime.UtcNow.DayOfWeek + i) % 7);

                int endTime = 0;

                // Today expires at +1 day, tomorrow at +2 days, etc.
                if (i != 0)
                {
                    endTime = (int)(todayMidnightUtc.AddDays(i) - DateTime.UtcNow).TotalSeconds;
                }

                result.AddRange(GetBossDataForDay(day, endTime));
            }

            return result;
        }

        /// <summary>
        /// Returns the boss entries for <paramref name="day"/>, each with <paramref name="endTime"/>
        /// as the value — the number of seconds until that boss slot expires.
        /// Falls back to an empty list if no schedule entry exists for that day.
        /// </summary>
        public List<Dictionary<string, int>> GetBossDataForDay(DayOfWeek day, int endTime)
        {
            var entry = DatabaseCollection
                .Find(x => x.DayOfWeek == (int)day)
                .FirstOrDefault();

            if (entry is null)
                return [];

            return entry.Bosses
                .Select(kvp => new Dictionary<string, int> { { kvp.Key, endTime } })
                .ToList();
        }
    }
}