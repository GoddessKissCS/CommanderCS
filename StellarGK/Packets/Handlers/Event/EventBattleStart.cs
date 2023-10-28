namespace StellarGK.Packets.Handlers.Event
{
    public class EventBattleStart
    {
    }
}

/*	// Token: 0x06006142 RID: 24898 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3741", true, true)]
	public void EventBattleStart(int type, JObject deck, JObject gdp, int ucash, int eidx, int efid, int np)
	{
	}

	// Token: 0x06006143 RID: 24899 RVA: 0x001B166C File Offset: 0x001AF86C
	private IEnumerator EventBattleStartResult(JsonRpcClient.Request request, string result, List<Protocols.RewardInfo.RewardData> reward)
	{
		BattleData battleData = BattleData.Get();
		battleData.rewardItems = reward;
		BattleData.Set(battleData);
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x06006144 RID: 24900 RVA: 0x001B1688 File Offset: 0x001AF888
	private IEnumerator EventBattleStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70201)
		{
			if (UIManager.instance.world != null)
			{
				UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("6601"), Localization.Get("1001"));
				uisimplePopup.onClose = delegate
				{
					if (UIManager.instance.world.readyBattle.isActive)
					{
						UIManager.instance.world.readyBattle.CloseAnimation();
					}
				};
			}
			if (UIManager.instance.battle != null && GameSetting.instance.repeatBattle)
			{
				GameSetting.instance.repeatBattle = false;
				UISimplePopup uisimplePopup2 = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("10000010"), Localization.Get("1001"));
			}
		}
		else if (code == 20002)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
			this.RequestGetUserInformation(Protocols.UserInformationType.Resource);
		}
		yield break;
	}*/