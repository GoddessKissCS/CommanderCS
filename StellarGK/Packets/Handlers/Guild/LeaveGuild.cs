namespace StellarGK.Packets.Handlers.Guild
{
    public class LeaveGuild
    {

    }
}
/*	// Token: 0x06006031 RID: 24625 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7217", true, true)]
	public void LeaveGuild()
	{
	}

	// Token: 0x06006032 RID: 24626 RVA: 0x001AFFCC File Offset: 0x001AE1CC
	private IEnumerator LeaveGuildResult(JsonRpcClient.Request request, string result)
	{
		this.localUser.guildInfo = null;
		this.localUser.ResetDispatchPossible();
		for (int i = 0; i < this.localUser.commanderList.Count; i++)
		{
			RoCommander roCommander = this.localUser.commanderList[i];
			if (roCommander.scramble || roCommander.occupation)
			{
				roCommander.role = "N";
			}
		}
		UIGuildManagePopup uiguildManagePopup = UnityEngine.Object.FindObjectOfType(typeof(UIGuildManagePopup)) as UIGuildManagePopup;
		if (uiguildManagePopup != null)
		{
			uiguildManagePopup.Close();
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/