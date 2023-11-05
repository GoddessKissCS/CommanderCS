namespace StellarGK.Packets.Handlers.Conquest
{
    public class ConquestJoin
    {
    }
}

/*	// Token: 0x0600605A RID: 24666 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7501", true, true)]
	public void ConquestJoin()
	{
	}

	// Token: 0x0600605B RID: 24667 RVA: 0x001B035C File Offset: 0x001AE55C
	private IEnumerator ConquestJoinResult(JsonRpcClient.Request request, string result)
	{
		NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110310"));
		UIManager.instance.world.guild.conquestInfo.sign = 1;
		UIManager.instance.world.guild.SetConquestStateLabel();
		yield break;
	}

	// Token: 0x0600605C RID: 24668 RVA: 0x001B0370 File Offset: 0x001AE570
	private IEnumerator ConquestJoinError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
		}
		else if (code = 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code = 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code = 71007)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		else if (code = 71511)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/