namespace StellarGK.Packets.Handlers.Situation
{
    public class SituationSweepStart
    {

    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3735", true, true)]
	public void SituationSweepStart(int type, int stype, int lv, JObject deck)
	{
	}

	// Token: 0x06005F7E RID: 24446 RVA: 0x001AF108 File Offset: 0x001AD308
	private IEnumerator SituationSweepStartResult(JsonRpcClient.Request request, string result, List<Protocols.RewardInfo.RewardData> reward)
	{
		BattleData battleData = BattleData.Get();
		battleData.rewardItems = reward;
		BattleData.Set(battleData);
		Loading.Load(Loading.Battle);
		yield break;
	}
    	private IEnumerator SituationSweepStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 11011)
		{
			if (UIManager.instance.world != null)
			{
				NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7044"));
			}
			if (UIManager.instance.battle != null && GameSetting.instance.repeatBattle)
			{
				GameSetting.instance.repeatBattle = false;
				UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("18045"), Localization.Get("1001"));
				uisimplePopup.onClose = delegate
				{
					BattleData battleData = BattleData.Get();
					BattleData.Set(battleData);
					if (battleData != null)
					{
						battleData.move = EBattleResultMove.Situation;
					}
					Loading.Load(Loading.WorldMap);
				};
			}
		}
		yield break;
	}

    */