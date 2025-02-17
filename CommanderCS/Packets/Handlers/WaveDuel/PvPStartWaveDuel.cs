namespace CommanderCS.Packets.Handlers.WaveDuel
{
    public class PvPStartWaveDuel
    {
    }
}

/*	// Token: 0x06005F9D RID: 24477 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3739", true, true)]
	public void PvPStartWaveDuel(int type, int idx, string checkSum, JArray info, JArray result)
	{
	}

	// Token: 0x06005F9E RID: 24478 RVA: 0x001AF3A8 File Offset: 0x001AD5A8
	private IEnumerator PvPStartWaveDuelResult(JsonRpcClient.Request request, object result)
	{
		BattleData battleData = BattleData.Get();
		BattleData.Set(battleData);
		if (battleData = null)
		{
			yield break;
		}
		if (battleData.type != EBattleType.GuildScramble && result = null)
		{
			yield break;
		}
		if (battleData.type != EBattleType.GuildScramble)
		{
			Protocols.UserInformationResponse.BattleResult battleResult = this._ConvertJObject<Protocols.UserInformationResponse.BattleResult>(result);
			if (battleData.type = EBattleType.WaveDuel)
			{
				battleData.dualResult = battleResult;
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
	}

	// Token: 0x06005F9F RID: 24479 RVA: 0x001AF3CC File Offset: 0x001AD5CC
	private IEnumerator PvPStartWaveDuelError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 70009)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("7044"), Localization.Get("1001"));
		}
		else if (code = 41050)
		{
			UISimplePopup uisimplePopup2 = UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Get("5040013"), null, "1001");
			uisimplePopup2.onClose = delegate
			{
				this.RequestRefreshPvPWaveDuelList();
				UIManager.instance.world.readyBattle.CloseAnimation();
			};
		}
		else
		{
			base.StartCoroutine(this.OnJsonRpcRequestError(request, result, code));
		}
		yield break;
	}*/