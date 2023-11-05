namespace StellarGK.Packets.Handlers.Guild
{
    public class FreeJoinGuild
    {
    }
}

/*	// Token: 0x06006024 RID: 24612 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7253", true, true)]
	public void FreeJoinGuild(int gidx)
	{
	}

	// Token: 0x06006025 RID: 24613 RVA: 0x001AFE9C File Offset: 0x001AE09C
	private IEnumerator FreeJoinGuildResult(JsonRpcClient.Request request, Protocols.GuildInfo result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshGuildFromNetwork(result.guildInfo);
		UIManager.instance.world.guild.InitGuildMemberList(result.memberData);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006026 RID: 24614 RVA: 0x001AFEC0 File Offset: 0x001AE0C0
	private IEnumerator FreeJoinGuildError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71301)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			int num = int.Parse(this._FindRequestProperty(request, "gidx"));
			UIManager.instance.world.guild.RomoveGuildList(num);
		}
		else if (code = 71302)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			int num2 = int.Parse(this._FindRequestProperty(request, "gidx"));
			UIManager.instance.world.guild.ChangeGuildItemType(num2, 2);
		}
		else if (code = 71303)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110219"));
		}
		else if (code = 71110)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110265"));
		}
		else if (code = 71111)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110266"));
		}
		else if (code = 71112)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110306"));
		}
		yield break;
	}*/