namespace StellarGK.Packets.Handlers.Conquest
{
    public class GetConquestCurrentStateInfo
    {
    }
}

/*	// Token: 0x06006075 RID: 24693 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7509", true, true)]
	public void GetConquestCurrentStateInfo()
	{
	}

	// Token: 0x06006076 RID: 24694 RVA: 0x001B05C0 File Offset: 0x001AE7C0
	private IEnumerator GetConquestCurrentStateInfoResult(JsonRpcClient.Request request, List<Protocols.ConquestStageInfo.User> result)
	{
		if (UIManager.instance.world.conquestMap.isActive)
		{
			UIManager.instance.world.conquestMap.CreateConquestCurrentPopup(result);
		}
		yield break;
	}

	// Token: 0x06006077 RID: 24695 RVA: 0x001B05DC File Offset: 0x001AE7DC
	private IEnumerator GetConquestCurrentStateInfoError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
		}
		else if (code == 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code == 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/