namespace StellarGK.Packets.Handlers.Guild
{
    public class CreateGuild
    {
    }
}

/*	// Token: 0x0600601F RID: 24607 RVA: 0x000492CD File Offset: 0x000474CD
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7212", true, true)]
	public void CreateGuild(string gnm, int gtyp, int lvlm, int emb)
	{
		this.tempNickName = this.localUser.nickname;
	}

	// Token: 0x06006020 RID: 24608 RVA: 0x001AFE40 File Offset: 0x001AE040
	private IEnumerator CreateGuildResult(JsonRpcClient.Request request, Protocols.GuildInfo result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshGuildFromNetwork(result.guildInfo);
		if (result.memberData == null)
		{
			this.localUser.nickname = this.tempNickName;
			List<Protocols.GuildMember.MemberData> list = new List<Protocols.GuildMember.MemberData>();
			list.Add(new Protocols.GuildMember.MemberData
			{
				uno = int.Parse(this.localUser.uno),
				thumnail = int.Parse(this.localUser.thumbnailId),
				name = this.localUser.nickname,
				level = this.localUser.level,
				lastTime = 10.0,
				memberGrade = 1,
				world = this.localUser.world
			});
			UIManager.instance.world.guild.InitGuildMemberList(list);
		}
		else
		{
			UIManager.instance.world.guild.InitGuildMemberList(result.memberData);
		}
		for (int i = 0; i < this.localUser.guildSkillList.Count; i++)
		{
			this.localUser.guildSkillList[i].skillLevel = 0;
		}
		NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("112011"));
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006021 RID: 24609 RVA: 0x001AFE64 File Offset: 0x001AE064
	private IEnumerator CreateGuildError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71005)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110021"));
		}
		else if (code == 71009)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110022"));
		}
		else if (code == 71303)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110219"));
		}
		yield break;
	}*/