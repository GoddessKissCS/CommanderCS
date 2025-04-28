using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Troop
{
    [Packet(Id = CommanderCS.Library.Shared.Enum.Method.ChangeTroopNickname)]
    public class ChangeTroopNickname : BaseMethodHandler<ChangeTroopNicknameRequest>
    {
        public override object Handle(ChangeTroopNicknameRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "ok",
            };

            return response;
        }
    }

    public class ChangeTroopNicknameRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5218", true, true)]
	public void ChangeTroopNickname(int cid, string name)
	{
	}

	// Token: 0x06005F50 RID: 24400 RVA: 0x001AED50 File Offset: 0x001ACF50
	private IEnumerator ChangeTroopNicknameResult(JsonRpcClient.Request request, string result)
	{
		string text = this._FindRequestProperty(request, "cid");
		string text2 = this._FindRequestProperty(request, "name");
		RoTroop roTroop = this.localUser.FindTroopByCommanderId(text);
		roTroop.nickname = text2;
		this._CheckReceiveTestData("TroopChangeNickname");
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F51 RID: 24401 RVA: 0x001AED74 File Offset: 0x001ACF74
	private IEnumerator ChangeTroopNicknameError(JsonRpcClient.Request request, string result, int code, string message)
	{
		if (code = 90001)
		{
		}
		UISimplePopup.CreateOK(false, "ChangeTroopNicknameError", code.ToString(), message, "확인");
		yield break;
	}*/