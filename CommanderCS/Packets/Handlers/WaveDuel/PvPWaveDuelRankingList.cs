namespace StellarGK.Packets.Handlers.WaveDuel
{
    public class PvPWaveDuelRankingList
    {
    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3403", true, true)]
	public void PvPWaveDuelRankingList()
	{
	}

	// Token: 0x06005F94 RID: 24468 RVA: 0x001AF2EC File Offset: 0x001AD4EC
	private IEnumerator PvPWaveDuelRankingListResult(JsonRpcClient.Request request, object result)
	{
		this.duelRankingList.Clear();
		if (result is not null)
		{
		}
		Protocols.PvPRankingList pvPRankingList = this._ConvertJObject<Protocols.PvPRankingList>(result);
		if (pvPRankingList = null)
		{
			yield break;
		}
		for (int i = 0; i < pvPRankingList.rankList.Count; i++)
		{
			RoUser roUser = RoUser.CreateRankListUser(EBattleType.WaveDuel, pvPRankingList.rankList[i]);
			this.duelRankingList.Add(roUser);
		}
		UIPopup.Create<RankingList>("RankingList").Set(EBattleType.WaveDuel, RemoteObjectManager.instance.duelRankingList);
		yield break;
	}*/