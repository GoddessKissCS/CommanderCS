using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Host;
using StellarGKLibrary.Enum;

namespace StellarGK.Packets.Handlers.UserTerm
{
    [Packet(Id = Method.ChangeDevice)]
    public class ChangeDevice : BaseMethodHandler<ChangeDeviceRequest>
    {
        public override object Handle(ChangeDeviceRequest @params)
        {
            ResponsePacket response = new();
            response.Id = BasePacket.Id;

            var ChangedDevice = DatabaseManager.Account.ChangeDevice(@params);

#warning TODO MAYBE CHANGE THE DEVICE AND ETC TO ACCOUNT RATHER THAN GAMEPROFILE?

            ChangeDeviceResponse changeDeviceResponse = new()
            {
                mIdx = ChangedDevice.MemberId,
                tokn = ChangedDevice.Token
            };

            response.Result = changeDeviceResponse;

            return response;

        }
    }

    public class ChangeDeviceRequest
    {
        [JsonProperty("ch")]
        public int ch { get; set; }

        [JsonProperty("dac")]
        public string dac { get; set; }

        [JsonProperty("uid")]
        public string uid { get; set; }

        [JsonProperty("pwd")]
        public string pwd { get; set; }

        [JsonProperty("plfm")]
        public Platform plfm { get; set; }

        [JsonProperty("devc")]
        public string devc { get; set; }

        [JsonProperty("dvid")]
        public string dvid { get; set; }

        [JsonProperty("ptype")]
        public int ptype { get; set; }

        [JsonProperty("oscd")]
        public OSCode oscd { get; set; }

        [JsonProperty("osvr")]
        public string osvr { get; set; }

        [JsonProperty("gmvr")]
        public string gmvr { get; set; }

        [JsonProperty("apk")]
        public string apk { get; set; }

        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("gpid")]
        public string gpid { get; set; }
    }


    internal class ChangeDeviceResponse
    {
        [JsonProperty("mIdx")]
        public int mIdx { get; set; }

        [JsonProperty("tokn")]
        public string tokn { get; set; }
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