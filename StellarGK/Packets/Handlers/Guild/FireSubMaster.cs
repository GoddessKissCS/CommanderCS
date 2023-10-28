namespace StellarGK.Packets.Handlers.Guild
{
    public class FireSubMaster
    {
    }
}

/*	// Token: 0x06006049 RID: 24649 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7258", true, true)]
	public void FireSubMaster(int tuno)
	{
	}

	// Token: 0x0600604A RID: 24650 RVA: 0x001B0200 File Offset: 0x001AE400
	private IEnumerator FireSubMasterResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "tuno"));
		UIManager.instance.world.guild.AppointSubMaster(false, num);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x0600604B RID: 24651 RVA: 0x001B0224 File Offset: 0x001AE424
	private IEnumerator FireSubMasterError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			int num = int.Parse(this._FindRequestProperty(request, "tuno"));
			UIManager.instance.world.guild.RemoveMemberList(num);
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110228"));
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		}
		yield break;
	}*/