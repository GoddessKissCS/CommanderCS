namespace CommanderCS.Packets.Handlers.Cooperate
{
    public class CooperateBattleStart
    {
    }
}

/*	// Token: 0x0600610E RID: 24846 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3733", true, true)]
	public void CooperateBattleStart(int type, JObject deck, int stage, int step)
	{
	}

	// Token: 0x0600610F RID: 24847 RVA: 0x001B11F4 File Offset: 0x001AF3F4
	private IEnumerator CooperateBattleStartResult(JsonRpcClient.Request request, bool result)
	{
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x06006110 RID: 24848 RVA: 0x001B1208 File Offset: 0x001AF408
	private IEnumerator CooperateBattleStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			if (UIManager.instance.world.guild.isActive)
			{
				UIManager.instance.world.guild.Close();
			}
		}
		else if (code = 71604)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("5090012"), Localization.Get("5090013"), null, "1001");
			uisimplePopup.onClose = delegate
			{
				this.RequestCooperateBattleInfo();
				if (UIManager.instance.world.readyBattle.isActive)
				{
					UIManager.instance.world.readyBattle.CloseAnimation();
				}
			};
		}
		else if (code = 71603)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("5090010"));
		}
		yield break;
	}*/