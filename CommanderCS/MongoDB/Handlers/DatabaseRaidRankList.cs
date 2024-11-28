using CommanderCSLibrary.Shared.Protocols;
using StellarGK.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing raid rank list data.
    /// </summary>
    public class DatabaseRaidRankList : DatabaseTable<RaidRankScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRaidRankList"/> class with the specified table name.
        /// </summary>
        public DatabaseRaidRankList() : base("RaidRankList")
        {
        }

        /// <summary>
        /// Inserts a new raid rank list entry into the database.
        /// </summary>
        /// <param name="uno">The unique identifier of the player.</param>
        /// <param name="rankingData">The ranking data of the player.</param>
        public void Insert(int uno, RankingUserData rankingData)
        {
            RaidRankScheme raidRank = new()
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
            };

            DatabaseCollection.InsertOne(raidRank);
        }
    }
}