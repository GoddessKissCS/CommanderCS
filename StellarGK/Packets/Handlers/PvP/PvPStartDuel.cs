namespace StellarGK.Packets.Handlers.PvP
{
    public class PvPStartDuel
    {
    }
}

/*	// Token: 0x06005F89 RID: 24457 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3738", true, true)]
	public void PvPStartDuel(int type, JObject deck, int idx, string checkSum, JArray info, JArray result)
	{
	}

	// Token: 0x06005F8A RID: 24458 RVA: 0x001AF228 File Offset: 0x001AD428
	private IEnumerator PvPStartDuelResult(JsonRpcClient.Request request, object result)
	{
		BattleData battleData = BattleData.Get();
		BattleData.Set(battleData);
		if (battleData == null)
		{
			yield break;
		}
		if (battleData.type != EBattleType.GuildScramble && result == null)
		{
			yield break;
		}
		if (battleData.type != EBattleType.GuildScramble)
		{
			Protocols.UserInformationResponse.BattleResult battleResult = this._ConvertJObject<Protocols.UserInformationResponse.BattleResult>(result);
			if (battleData.type == EBattleType.Duel)
			{
				battleData.dualResult = battleResult;
				this.localUser.duelPoint = battleResult.user.duelPoint;
				if (battleData.record.result.IsWin)
				{
					if (GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED)
					{
						RemoteObjectManager.statistics.pvpWinCount++;
						if (RemoteObjectManager.statistics.pvpWinCount >= 10)
						{
							SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQCg");
						}
						if (RemoteObjectManager.statistics.pvpWinCount >= 100)
						{
							SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQCw");
						}
						if (RemoteObjectManager.statistics.pvpWinCount >= 300)
						{
							SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQDA");
						}
						if (RemoteObjectManager.statistics.pvpWinCount >= 500)
						{
							SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQDQ");
						}
						if (RemoteObjectManager.statistics.pvpWinCount >= 1000)
						{
							SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQDg");
						}
					}
					if (GameCenterManager.IsPlayerAuthenticated)
					{
						RemoteObjectManager.statistics.pvpWinCount++;
						if (RemoteObjectManager.statistics.pvpWinCount == 10)
						{
							GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQCg");
						}
						else if (RemoteObjectManager.statistics.pvpWinCount == 100)
						{
							GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQCw");
						}
						else if (RemoteObjectManager.statistics.pvpWinCount == 300)
						{
							GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQDA");
						}
						else if (RemoteObjectManager.statistics.pvpWinCount == 500)
						{
							GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQDQ");
						}
						else if (RemoteObjectManager.statistics.pvpWinCount == 1000)
						{
							GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQDg");
						}
					}
				}
				this.localUser.RefreshGoodsFromNetwork(battleResult.resource);
				this.localUser.RefreshPartFromNetwork(battleResult.partData);
				this.localUser.RefreshMedalFromNetwork(battleResult.medalData);
				this.localUser.RefreshFavorFromNetwork(battleResult.commanderFavor);
				this.localUser.RefreshItemFromNetwork(battleResult.eventResourceData);
				this.localUser.RefreshItemFromNetwork(battleResult.itemData);
			}
		}
		Loading.Load(Loading.Battle);
		yield break;
	}*/