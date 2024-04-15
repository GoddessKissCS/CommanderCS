using CommanderCSLibrary.Shared.Protocols;
using StellarGK.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing PvP rank list data.
    /// </summary>
    public class DatabasePvpRankList : DatabaseTable<PvpRankListScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabasePvpRankList"/> class with the specified table name.
        /// </summary>
        public DatabasePvpRankList() : base("PvpRankList")
        {
        }

        /// <summary>
        /// Inserts a new PvP rank list entry into the database.
        /// </summary>
        /// <param name="uno">The unique identifier of the player.</param>
        /// <param name="rankingData">The ranking data of the player.</param>
        /// <param name="deck">The player's deck.</param>
        public void Insert(int uno, RankingUserData rankingData, Dictionary<string, string> deck)
        {
            PvpRankListScheme rankList = new()
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
                Deck = deck
            };

            DatabaseCollection.InsertOne(rankList);
        }
    }
}