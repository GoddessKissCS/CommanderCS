using MongoDB.Driver;
using StellarGK.Database;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGK.Logic.Enums;
using StellarGK.Tools;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.UserTerm
{
    [Packet(Id = Method.ChangeDeviceDbros)]
    public class ChangeDeviceDbros : BaseMethodHandler<ChangeDeviceDbrosRequest>
    {
#warning TODO NO IDEA CURRENTLY HOW TO SOLVE THIS
        public override object Handle(ChangeDeviceDbrosRequest @params)
        {
            ResponsePacket response = new();
            response.Id = BasePacket.Id;

            ErrorCode code = DatabaseManager.Account.ChangeMemberShipDbros(@params.plfm, @params.uid, @params.pwd);

            if (code == ErrorCode.IdAlreadyExists || code == ErrorCode.InappropriateWords)
            {
                response.Error = new() { code = code };
                
                return response;
            }

            response.Result = "{}";
            return response;

        }
    }

    public class ChangeDeviceDbrosRequest
    {
        [JsonPropertyName("ch")]
        public int ch { get; set; }

        [JsonPropertyName("dac")]
        public string dac { get; set; }

        [JsonPropertyName("uid")]
        public string uid { get; set; }

        [JsonPropertyName("pwd")]
        public string pwd { get; set; }

        [JsonPropertyName("plfm")]
        public Platform plfm { get; set; }

        [JsonPropertyName("devc")]
        public string devc { get; set; }

        [JsonPropertyName("dvid")]
        public string dvid { get; set; }

        [JsonPropertyName("ptype")]
        public int ptype { get; set; }

        [JsonPropertyName("oscd")]
        public OSCode oscd { get; set; }

        [JsonPropertyName("osvr")]
        public string osvr { get; set; }

        [JsonPropertyName("gmvr")]
        public string gmvr { get; set; }

        [JsonPropertyName("apk")]
        public string apk { get; set; }

        [JsonPropertyName("lang")]
        public string lang { get; set; }

        [JsonPropertyName("gpid")]
        public string gpid { get; set; }
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