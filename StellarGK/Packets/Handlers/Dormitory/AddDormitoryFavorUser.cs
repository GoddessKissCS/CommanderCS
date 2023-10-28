namespace StellarGK.Packets.Handlers.Dormitory
{
    public class AddDormitoryFavorUser
    {
    }
}/*	// Token: 0x060061D4 RID: 25044 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8661", true, true)]
	public void AddDormitoryFavorUser(string tuno)
	{
	}

	// Token: 0x060061D5 RID: 25045 RVA: 0x001B2180 File Offset: 0x001B0380
	private IEnumerator AddDormitoryFavorUserResult(JsonRpcClient.Request request, string result)
	{
		string text = this._FindRequestProperty(request, "tuno");
		if (SingletonMonoBehaviour<DormitoryData>.Instance.user.uno == text)
		{
			SingletonMonoBehaviour<DormitoryData>.Instance.favorState = true;
			Message.Send("User.Update.FavorState");
		}
		Message.Send<string>("Favor.Add", text);
		yield break;
	}

	// Token: 0x060061D6 RID: 25046 RVA: 0x001B21A4 File Offset: 0x001B03A4
	private IEnumerator AddDormitoryFavorUserResultError(JsonRpcClient.Request request, string result, int code)
	{
		if (code != 85171)
		{
			if (code != 85172)
			{
			}
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81065"));
		}
		yield break;
	}*/