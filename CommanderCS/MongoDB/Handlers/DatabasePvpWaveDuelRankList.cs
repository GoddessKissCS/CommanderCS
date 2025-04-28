using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Protocols;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing PvP wave duel rank list data.
    /// </summary>
    public class DatabasePvpWaveDuelRankList : DatabaseTable<PvpWaveDuelRankListScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabasePvpWaveDuelRankList"/> class with the specified table name.
        /// </summary>
        public DatabasePvpWaveDuelRankList() : base("PvpWaveDuelRankList")
        {
        }

        /// <summary>
        /// Inserts a new PvP wave duel rank list entry into the database.
        /// </summary>
        /// <param name="uno">The unique identifier of the player.</param>
        /// <param name="rankingData">The ranking data of the player.</param>
        /// <param name="decks">The player's decks.</param>
        public void Insert(int uno, RankingUserData rankingData, Dictionary<string, Dictionary<string, string>> decks)
        {
            PvpWaveDuelRankListScheme waveduel = new()
            {
                Uno = uno,
                Score = rankingData.score,
                AverageScore = rankingData.averageScore,
                BestScore = rankingData.bestScore,
                LosingStreak = rankingData.losingStreak,
                NextScore = rankingData.nextScore,
                WinningStreak = rankingData.winningStreak,
                DuelPoint = rankingData.duelPoint,
                LoseCount = rankingData.loseCnt,
                RaidCount = rankingData.raidCnt,
                RaidRank = rankingData.raidRank,
                RaidRewardPoint = rankingData.raidRewardPoint,
                RankingRate = rankingData.rankingRate,
                Ranking = rankingData.ranking,
                RewardDuelPoint = rankingData.rewardDuelPoint,
                RewardId = rankingData.rewardId,
                WinCount = rankingData.winCnt,
                WinRank = rankingData.winRank,
                WinRankIdx = rankingData.winRankIdx,
                Decks = decks
            };

            DatabaseCollection.InsertOne(waveduel);
        }
    }
}