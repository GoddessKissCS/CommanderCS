namespace StellarGK.Packets.Handlers.UserTerm
{
    public class ChangeDeviceDbros
    {

    }
}
/*	// Token: 0x060060DA RID: 24794 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1234", true, true)]
	public void ChangeDeviceDbros(int ch, string dac, string uid, string pwd, Platform plfm, string devc, string dvid, int ptype, Protocols.OSCode oscd, string osvr, string gmvr, string apk, string lang, string gpid)
	{
	}

	// Token: 0x060060DB RID: 24795 RVA: 0x001B0DC4 File Offset: 0x001AEFC4
	private IEnumerator ChangeDeviceDbrosResult(JsonRpcClient.Request request, bool result, int mIdx, string tokn)
	{
		string text = this._FindRequestProperty(request, "uid");
		string text2 = this._FindRequestProperty(request, "pwd");
		PlayerPrefs.SetString("MemberID", text);
		PlayerPrefs.SetString("MemberPW", text2);
		RemoteObjectManager.instance.RequestSignIn(text, text2);
		yield break;
	}

	// Token: 0x060060DC RID: 24796 RVA: 0x001B0DE8 File Offset: 0x001AEFE8
	private IEnumerator ChangeDeviceDbrosError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 10014)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("19033"));
		}
		else if (code == 20014)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("7054"));
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error code:" + code);
		}
		yield break;
	}*/