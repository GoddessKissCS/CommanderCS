namespace StellarGK.Packets.Handlers.Guild
{
    public class ApproveGuildJoin
    {

    }
}
/*	// Token: 0x06006038 RID: 24632 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7255", true, true)]
	public void ApproveGuildJoin(int uno)
	{
	}

	// Token: 0x06006039 RID: 24633 RVA: 0x001B004C File Offset: 0x001AE24C
	private IEnumerator ApproveGuildJoinResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "uno"));
		UIGuildMemberJoinPopUp uiguildMemberJoinPopUp = UnityEngine.Object.FindObjectOfType(typeof(UIGuildMemberJoinPopUp)) as UIGuildMemberJoinPopUp;
		if (uiguildMemberJoinPopUp != null)
		{
			uiguildMemberJoinPopUp.AddGildMember(num);
		}
		yield break;
	}

	// Token: 0x0600603A RID: 24634 RVA: 0x001B0070 File Offset: 0x001AE270
	private IEnumerator ApproveGuildJoinError(JsonRpcClient.Request request, string result, int code)
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