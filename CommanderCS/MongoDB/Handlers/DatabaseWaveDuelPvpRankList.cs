using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing wave duel PvP rank list information.
    /// </summary>
    public class DatabaseWaveDuelPvpRankList : DatabaseTable<GuildScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseWaveDuelPvpRankList"/> class with the specified table name.
        /// </summary>
        public DatabaseWaveDuelPvpRankList() : base("WaveDuelPvpRankList")
        {
        }
    }
}