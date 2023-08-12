namespace StellarGK.Packets.Handlers.UserTerm
{
    public class ChangeDevice
    {

    }
}
/*	// Token: 0x060060D1 RID: 24785 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1233", true, true)]
	public void ChangeDevice(int ch, string dac, string tokn, Platform plfm, string devc, string dvid, int ptype, Protocols.OSCode oscd, string osvr, string gmvr, string apk, string lang, string gpid)
	{
	}

	// Token: 0x060060D2 RID: 24786 RVA: 0x001B0D28 File Offset: 0x001AEF28
	private IEnumerator ChangeDeviceResult(JsonRpcClient.Request request, bool result, int mIdx, string tokn)
	{
		Platform platform = (Platform)int.Parse(this._FindRequestProperty(request, "plfm"));
		PlayerPrefs.SetString("MemberID", this.localUser.platformUserInfo);
		PlayerPrefs.SetString("MemberPW", null);
		PlayerPrefs.SetInt("MemberPlatform", (int)platform);
		this.localUser.mIdx = mIdx;
		this.localUser.tokn = tokn;
		this.localUser.platform = platform;
		LocalStorage.SaveLoginData(this.localUser.platformUserInfo, null, (int)platform);
		RemoteObjectManager.instance.bLogin = true;
		yield break;
	}*/