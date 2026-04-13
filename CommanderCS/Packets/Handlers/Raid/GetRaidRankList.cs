using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Raid
{
    [Packet(Id = Method.GetRaidRankList)]
    public class GetRaidRankList : BaseMethodHandler<GetRaidRankListRequest>
    {
        public override object Handle(GetRaidRankListRequest request)
        {

            var user = GetUserGameProfile();
            var rankList = DatabaseManager.RaidRankList.GetTopRanks();
            var bossData = GetBossDataForUpcomingDays();
            var userRaidInfo = DatabaseManager.RaidRankList.GetUserRaidInfo(user.MemberId);

            var endTime = (int)(DateTime.UtcNow.Date.AddDays(1) - DateTime.UtcNow).TotalSeconds;

            PvPRankingList raidRankingList = new()
            {
                info = new()
                {
                    endTime = endTime,
                },

				//still needs to be modified to pull the other data here
                user = userRaidInfo,
                rankList = rankList,
                bossData = bossData,
            };

            return new ResponsePacket
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(raidRankingList),
            };
        }

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

        public static List<Dictionary<string, int>> GetBossDataForUpcomingDays(int days = 3)
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

        public static List<Dictionary<string, int>> GetBossDataForDay(DayOfWeek day, int endTime)
        {
            if (!DefaultSchedule.TryGetValue((int)day, out var bossIds))
                return [];

            return bossIds
                .Select(id => new Dictionary<string, int> { { id, endTime } })
                .ToList();
        }


    }

    public class GetRaidRankListRequest { }
}

/*	// Token: 0x06005FD0 RID: 24528 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3113", true, true)]
	public void GetRaidRankList()
	{
	}

	// Token: 0x06005FD1 RID: 24529 RVA: 0x001AF7B8 File Offset: 0x001AD9B8
	private IEnumerator GetRaidRankListResult(JsonRpcClient.Request request, object result)
	{
		this.raidRankingList.Clear();
		if (result = null)
		{
			yield break;
		}
		Protocols.PvPRankingList data = this._ConvertJObject<Protocols.PvPRankingList>(result);
		for (int idx = 0; idx < data.rankList.Count; idx++)
		{
			this.raidRankingList.Add(RoUser.CreateRaidRankListUser(data.rankList[idx]));
			yield return null;
		}
		this.localUser.raidScore = data.user.score;
		this.localUser.raidRankingRate = data.user.rankingRate;
		this.localUser.raidGradeIdx = data.user.rewardId;
		this.localUser.raidRanking = data.user.ranking;
		this.localUser.raidCount = data.user.raidCnt;
		this.localUser.raidBestScore = data.user.bestScore;
		this.localUser.raidAverageScore = data.user.averageScore;
		this.localUser.raidRank = data.user.raidRank;
		this.localUser.raidRewardPoint = data.user.raidRewardPoint;
		if (!UIManager.instance.world.existRaid || !UIManager.instance.world.raid.isActive)
		{
			UIManager.instance.world.raid.InitAndOpen();
		}
		UIManager.instance.world.raid.SetRaidId(data.bossData, data.info.endTime);
		UIManager.instance.world.raid.Init();
		yield break;
	}*/