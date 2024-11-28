using MongoDB.Bson;
using Newtonsoft.Json;

namespace StellarGK.MongoDB.Schemes
{
    /// <summary>
    /// Represents a PvP rank list scheme.
    /// </summary>
    public class PvpWaveDuelRankListScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the unique number.
        /// </summary>
        public int Uno { get; set; }

        /// <summary>
        /// Gets or sets the ranking.
        /// </summary>
        [JsonProperty("rank")]
        public int Ranking { get; set; }

        /// <summary>
        /// Gets or sets the ranking rate.
        /// </summary>
        [JsonProperty("prct")]
        public float RankingRate { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        [JsonProperty("score")]
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the next score.
        /// </summary>
        [JsonProperty("nScore")]
        public int NextScore { get; set; }

        /// <summary>
        /// Gets or sets the winning streak.
        /// </summary>
        [JsonProperty("wst")]
        public int WinningStreak { get; set; }

        /// <summary>
        /// Gets or sets the losing streak.
        /// </summary>
        [JsonProperty("lst")]
        public int LosingStreak { get; set; }

        /// <summary>
        /// Gets or sets the win count.
        /// </summary>
        [JsonProperty("win")]
        public int WinCount { get; set; }

        /// <summary>
        /// Gets or sets the lose count.
        /// </summary>
        [JsonProperty("lose")]
        public int LoseCount { get; set; }

        /// <summary>
        /// Gets or sets the raid count.
        /// </summary>
        [JsonProperty("rcnt")]
        public int RaidCount { get; set; }

        /// <summary>
        /// Gets or sets the best score.
        /// </summary>
        [JsonProperty("nscr")]
        public int BestScore { get; set; }

        /// <summary>
        /// Gets or sets the average score.
        /// </summary>
        [JsonProperty("avrg")]
        public int AverageScore { get; set; }

        /// <summary>
        /// Gets or sets the reward ID.
        /// </summary>
        [JsonProperty("ridx")]
        public int RewardId { get; set; }

        /// <summary>
        /// Gets or sets the duel point.
        /// </summary>
        [JsonProperty("dpnt")]
        public int DuelPoint { get; set; }

        /// <summary>
        /// Gets or sets the reward duel point.
        /// </summary>
        [JsonProperty("didx")]
        public int RewardDuelPoint { get; set; }

        /// <summary>
        /// Gets or sets the win rank.
        /// </summary>
        [JsonProperty("wrank")]
        public int WinRank { get; set; }

        /// <summary>
        /// Gets or sets the win rank index.
        /// </summary>
        [JsonProperty("wridx")]
        public int WinRankIdx { get; set; }

        /// <summary>
        /// Gets or sets the raid rank.
        /// </summary>
        [JsonProperty("drank")]
        public int RaidRank { get; set; }

        /// <summary>
        /// Gets or sets the raid reward point.
        /// </summary>
        [JsonProperty("dridx")]
        public int RaidRewardPoint { get; set; }

        /// <summary>
        /// Gets or sets the deck.
        /// </summary>
        [JsonProperty("decks")]
        public Dictionary<string, Dictionary<string, string>> Decks { get; set; }
    }
}