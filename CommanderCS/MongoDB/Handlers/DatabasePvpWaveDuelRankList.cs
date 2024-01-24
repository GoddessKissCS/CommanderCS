using CommanderCS.MongoDB.Schemes;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Protocols;
using StellarGK.MongoDB.Schemes;

namespace StellarGK.MongoDB.Handlers
{
    public class DatabasePvpWaveDuelRankList : DatabaseTable<PvpWaveDuelRankListScheme>
    {
        public DatabasePvpWaveDuelRankList() : base("PvpWaveDuelRankList")
        {
        }
        public void Insert(int uno, RankingUserData rankingData, Dictionary<string, Dictionary<string, string>> decks)
        {

            //TODO: NEEDS TO BE ADJUSTED FOR RANKING AND ETC
            PvpWaveDuelRankListScheme waveduel = new()
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
                decks = decks      
            };


            DatabaseCollection.InsertOne(waveduel);
        }
    }
}
