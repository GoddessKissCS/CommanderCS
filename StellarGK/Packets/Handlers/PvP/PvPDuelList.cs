namespace StellarGK.Packets.Handlers.PvP
{
    public class PvPDuelList
    {
    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3125", true, true)]
	public void PvPDuelList()
	{
	}

	// Token: 0x06005F86 RID: 24454 RVA: 0x001AF1D8 File Offset: 0x001AD3D8
	private IEnumerator PvPDuelListResult(JsonRpcClient.Request request, Protocols.PvPDuelList result)
	{
		this.localUser.duelTargetList.Clear();
		this.localUser.duelTargetRefreshTime.SetByDuration((double)result.remain);
		this.localUser.currentSeasonDuelTime.SetByDuration((double)result.time);
		if (result.duelList != null)
		{
			for (int i = 1; i <= result.duelList.Count; i++)
			{
				this.localUser.duelTargetList.Add(result.duelList[i].idx, RoUser.CreateDuelListUser(EBattleType.Duel, result.duelList[i]));
			}
		}
		if (result.user != null)
		{
			this.localUser.duelScore = result.user.score;
			this.localUser.duelNextScore = result.user.nextScore;
			this.localUser.duelGradeIdx = result.user.rewardId;
			this.localUser.duelWinningStreak = Mathf.Max(result.user.winningStreak - 1, 0);
			this.localUser.duelLosingStreak = Mathf.Max(result.user.losingStreak - 1, 0);
			this.localUser.duelRanking = result.user.ranking;
			this.localUser.duelRankingRate = result.user.rankingRate;
			this.localUser.duelWinCount = result.user.winCnt;
			this.localUser.duelLoseCount = result.user.loseCnt;
			this.localUser.duelPoint = result.user.duelPoint;
			this.localUser.rewardDuelPoint = result.user.rewardDuelPoint;
			this.localUser.winRank = result.user.winRank;
			this.localUser.winRankIdx = result.user.winRankIdx;
		}
		UIManager.instance.world.rankingBattle.InitAndOpen(EBattleType.Duel);
		yield break;
	}*/