namespace StellarGK.Packets.Handlers.Guild
{
    public class RefuseGuildJoin
    {

    }
}
/*	// Token: 0x0600603B RID: 24635 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7256", true, true)]
	public void RefuseGuildJoin(int uno)
	{
	}

	// Token: 0x0600603C RID: 24636 RVA: 0x001B009C File Offset: 0x001AE29C
	private IEnumerator RefuseGuildJoinResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "uno"));
		UIGuildMemberJoinPopUp uiguildMemberJoinPopUp = UnityEngine.Object.FindObjectOfType(typeof(UIGuildMemberJoinPopUp)) as UIGuildMemberJoinPopUp;
		if (uiguildMemberJoinPopUp != null)
		{
			uiguildMemberJoinPopUp.RemoveJoinMember(num);
		}
		yield break;
	}

	// Token: 0x0600603D RID: 24637 RVA: 0x001B00C0 File Offset: 0x001AE2C0
	private IEnumerator RefuseGuildJoinError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71305)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110221"));
		}
		else if (code == 71306)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110307"));
			int num = int.Parse(this._FindRequestProperty(request, "uno"));
			UIGuildMemberJoinPopUp uiguildMemberJoinPopUp = UnityEngine.Object.FindObjectOfType(typeof(UIGuildMemberJoinPopUp)) as UIGuildMemberJoinPopUp;
			if (uiguildMemberJoinPopUp != null)
			{
				uiguildMemberJoinPopUp.RemoveJoinMember(num);
			}
		}
		else if (code == 71007 || code == 71018 || code == 71107)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			UIGuildMemberJoinPopUp uiguildMemberJoinPopUp2 = UnityEngine.Object.FindObjectOfType(typeof(UIGuildMemberJoinPopUp)) as UIGuildMemberJoinPopUp;
			if (uiguildMemberJoinPopUp2 != null)
			{
				uiguildMemberJoinPopUp2.Close();
			}
			UIManager.instance.world.guild.Close();
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		}
		yield break;
	}*/