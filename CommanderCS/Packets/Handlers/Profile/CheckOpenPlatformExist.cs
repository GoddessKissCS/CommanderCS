using CommanderCS.Library.Enums;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Profile
{
    public class CheckOpenPlatformExist
    {
    }

    public class CheckOpenPlatformExistRequest
    {
        [JsonProperty("plfm")]
        public Platform Plfm { get; set; }

        [JsonProperty("tokn")]
        public string Tokn { get; set; }

        [JsonProperty("ch")]
        public int Ch { get; set; }
    }
}

/*	// Token: 0x060060CF RID: 24783 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1232", true, true)]
	public void CheckOpenPlatformExist(Platform plfm, string tokn, int ch)
	{
	}

	// Token: 0x060060D0 RID: 24784 RVA: 0x001B0CFC File Offset: 0x001AEEFC
	private IEnumerator CheckOpenPlatformExistResult(JsonRpcClient.Request request, bool result)
	{
		Platform plfm = (Platform)int.Parse(this._FindRequestProperty(request, "plfm"));
		if (result)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateBool(true, "19527", (plfm != Platform.FaceBook) ? "19529" : "19528", null, "1001", "1000");
			uisimplePopup.onClick = delegate(GameObject popupSender)
			{
				string name = popupSender.name;
				if (name = "OK")
				{
					if (this.localUser.loginType = 1)
					{
						this.RequestChangeDevice(plfm);
					}
					else
					{
						this.RequestChangeMembershipOpenPlatform(this.localUser.openPlatformToken, plfm, PlayerPrefs.GetString("GuestID"));
					}
				}
			};
		}
		else if (this.localUser.loginType = 1)
		{
			this.RequestChangeDevice(plfm);
		}
		else
		{
			this.RequestChangeMembershipOpenPlatform(this.localUser.openPlatformToken, plfm, PlayerPrefs.GetString("GuestID"));
		}
		yield break;
	}*/