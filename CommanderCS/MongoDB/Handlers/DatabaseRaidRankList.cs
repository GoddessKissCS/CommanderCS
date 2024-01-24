using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Protocols;
using StellarGK.MongoDB.Schemes;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseRaidRankList : DatabaseTable<RaidRankScheme>
    {
        public DatabaseRaidRankList() : base("RaidRankList")
        {
        }

        public void Insert(int uno, RankingUserData rankingData)
        {

//TODO: NEEDS TO BE ADJUSTED FOR RANKING AND ETC
            RaidRankScheme raidRank = new()
            {
                Uno = uno,
                score = rankingData.score,
                averageScore = rankingData.averageScore,
                bestScore = rankingData.bestScore,
                losingStreak = rankingData.losingStreak,
                nextScore = rankingData.nextScore,
                winningStreak = rankingData.winningStreak,
                duelPoint = rankingData.duelPoint,
                loseCnt = rankingData.loseCnt,
                raidCnt = rankingData.raidCnt,
                raidRank = rankingData.raidRank,
                raidRewardPoint = rankingData.raidRewardPoint,
                rankingRate = rankingData.rankingRate,
                ranking = rankingData.ranking,
                rewardDuelPoint = rankingData.rewardDuelPoint,
                rewardId = rankingData.rewardId,
                winCnt = rankingData.winCnt,
                winRank = rankingData.winRank,
                winRankIdx = rankingData.winRankIdx,
            };


            DatabaseCollection.InsertOne(raidRank);
        }

    }
}