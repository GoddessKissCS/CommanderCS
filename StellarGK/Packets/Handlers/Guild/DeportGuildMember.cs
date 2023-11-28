namespace CommanderCS.Packets.Handlers.Guild
{
    public class DeportGuildMember
    {
    }
}

/*	// Token: 0x06006043 RID: 24643 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7216", true, true)]
	public void DeportGuildMember(int tuno)
	{
	}

	// Token: 0x06006044 RID: 24644 RVA: 0x001B0160 File Offset: 0x001AE360
	private IEnumerator DeportGuildMemberResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "tuno"));
		UIManager.instance.world.guild.RemoveMemberList(num);
		yield break;
	}

	// Token: 0x06006045 RID: 24645 RVA: 0x001B0184 File Offset: 0x001AE384
	private IEnumerator DeportGuildMemberError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			int num = int.Parse(this._FindRequestProperty(request, "tuno"));
			UIManager.instance.world.guild.RemoveMemberList(num);
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110228"));
		}
		else if (code = 71307)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110118"));
		}
		yield break;
	}*/