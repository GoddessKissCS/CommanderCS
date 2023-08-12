namespace StellarGK.Packets.Handlers.Guild
{
    public class UpgradeGuildLevel
    {

    }
}
/*	// Token: 0x0600604F RID: 24655 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7222", true, true)]
	public void UpgradeGuildLevel()
	{
	}

	// Token: 0x06006050 RID: 24656 RVA: 0x001B0290 File Offset: 0x001AE490
	private IEnumerator UpgradeGuildLevelResult(JsonRpcClient.Request request, Protocols.GuildInfo result)
	{
		this.localUser.guildInfo.point = result.guildInfo.point;
		this.localUser.guildInfo.level = result.guildInfo.level;
		this.localUser.guildInfo.maxCount = result.guildInfo.maxCount;
		UIGuildManagePopup uiguildManagePopup = UnityEngine.Object.FindObjectOfType(typeof(UIGuildManagePopup)) as UIGuildManagePopup;
		if (uiguildManagePopup != null)
		{
			uiguildManagePopup.OnRefresh();
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/