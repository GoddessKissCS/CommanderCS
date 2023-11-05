namespace StellarGK.Packets.Handlers.Conquest
{
    public class StartConquestRadar
    {
    }
}

/*	// Token: 0x06006078 RID: 24696 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7511", true, true)]
	public void StartConquestRadar()
	{
	}

	// Token: 0x06006079 RID: 24697 RVA: 0x001B05F8 File Offset: 0x001AE7F8
	private IEnumerator StartConquestRadarResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, Protocols.GetRadarData.Radar radar)
	{
		if (!string.IsNullOrEmpty(result))
		{
			this.localUser.RefreshGoodsFromNetwork(rsoc);
			UIConquestMap conquestMap = UIManager.instance.world.conquestMap;
			if (conquestMap.isActive)
			{
				radar.overTime = 1;
				conquestMap.StartRadar(radar);
			}
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x0600607A RID: 24698 RVA: 0x001B062C File Offset: 0x001AE82C
	private IEnumerator StartConquestRadarError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.Close();
		}
		else if (code = 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
			UIManager.instance.world.guild.Close();
		}
		else if (code = 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
			UIManager.instance.world.guild.Close();
		}
		else if (code = 71509)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
			if (uisimplePopup != null)
			{
				uisimplePopup.onClose = delegate
				{
					this.RequestGetConquestRadar();
				};
			}
		}
		else if (code = 20002)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
			this.ReqeustRenewUserGameData();
		}
		yield break;
	}*/