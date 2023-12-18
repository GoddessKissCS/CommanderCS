using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Packets.Handlers.Raid
{
    [Packet(Id = Method.GetRaidRankList)]
    public class GetRaidRankList : BaseMethodHandler<GetRaidRankListRequest>
    {
        public override object Handle(GetRaidRankListRequest @params)
        {
            ResponsePacket response = new ResponsePacket()
            {
                Id = BasePacket.Id,
                Result = null,
            };

            PvPRankingList pvPRankingList = new();

            return response;
        }
    }

    public class GetRaidRankListRequest
    {
    }
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