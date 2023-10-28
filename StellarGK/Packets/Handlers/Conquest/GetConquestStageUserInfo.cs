namespace StellarGK.Packets.Handlers.Conquest
{
    public class GetConquestStageUserInfo
    {
    }
}

/*	// Token: 0x0600607E RID: 24702 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7513", true, true)]
	public void GetConquestStageUserInfo(int tuno, int point)
	{
	}

	// Token: 0x0600607F RID: 24703 RVA: 0x001B0688 File Offset: 0x001AE888
	private IEnumerator GetConquestStageUserInfoResult(JsonRpcClient.Request request, List<Protocols.ConquestStageUser> result)
	{
		if (result.Count > 0 && UIManager.instance.world.conquestMap.isActive && UIManager.instance.world.conquestMap.stagePopup != null)
		{
			UIManager.instance.world.conquestMap.stagePopup.CreateAlieUserDeckPopup(result);
		}
		yield break;
	}

	// Token: 0x06006080 RID: 24704 RVA: 0x001B06A4 File Offset: 0x001AE8A4
	private IEnumerator GetConquestStageUserInfoError(JsonRpcClient.Request request, string result, int code)
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