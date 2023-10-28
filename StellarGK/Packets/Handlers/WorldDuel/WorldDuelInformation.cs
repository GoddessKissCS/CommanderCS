namespace StellarGK.Packets.Handlers.WorldDuel
{
    public class WorldDuelInformation
    {
    }

    public class WorldDuelInformationRequest
    {
    }
}

/*	// Token: 0x0600614E RID: 24910 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3601", true, true)]
	public void WorldDuelInformation()
	{
	}

	// Token: 0x0600614F RID: 24911 RVA: 0x001B175C File Offset: 0x001AF95C
	private IEnumerator WorldDuelInformationResult(JsonRpcClient.Request request, Protocols.WorldDuelInformation result)
	{
		if (result != null)
		{
			this.localUser.currentSeasonDuelTime.SetByDuration(result.resetTime);
			this.localUser.RefreshDefenderTroop(result.deck);
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.worldDuelBattleEnable = result.open;
			this.localUser.worldDuelBuff = result.duelBuff;
			this.localUser.RefreshWorldDuelActiveBuffFromNetwork(result.activeBuff);
			if (this.duelRankingList == null)
			{
				this.duelRankingList = new List<RoUser>();
			}
			this.duelRankingList.Clear();
			for (int i = 0; i < result.rankingList.Count; i++)
			{
				RoUser roUser = RoUser.CreateRankListUser(EBattleType.WorldDuel, result.rankingList[i]);
				this.duelRankingList.Add(roUser);
			}
			if (result.bestRank.world != 0)
			{
				this.localUser.worldDuelBestRank = RoUser.CreateRankListUser(result.bestRank);
			}
			else
			{
				this.localUser.worldDuelBestRank = null;
			}
			if (result.retryInfo.uno != 0)
			{
				this.localUser.worldDuelReMatchTarget = RoUser.CreateDuelListUser(EBattleType.WorldDuel, result.retryInfo);
			}
			else
			{
				this.localUser.worldDuelReMatchTarget = null;
			}
			this.localUser.worldDuelRanking = result.user.ranking;
			this.localUser.worldDuelScore = result.user.score;
			this.localUser.worldWinRank = result.user.winRank;
			this.localUser.worldWinRankIdx = result.user.winRankIdx;
			this.localUser.worldWinCount = result.user.winCnt;
			this.localUser.worldLoseCount = result.user.loseCnt;
			this.localUser.duelGradeIdx = this.localUser.GetWorldDuelRankGrade();
			UIManager.instance.world.rankingBattle.InitAndOpen(EBattleType.WorldDuel);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006150 RID: 24912 RVA: 0x001B1780 File Offset: 0x001AF980
	private IEnumerator WorldDuelInformationError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/