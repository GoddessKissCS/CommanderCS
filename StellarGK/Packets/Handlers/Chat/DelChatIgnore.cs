using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Host;

namespace StellarGK.Packets.Handlers.Chat
{
    [Command(Id = CommandId.DelChatIgnore)]
    public class DelChatIgnore : BaseCommandHandler<DelChatIgnoreRequest>
    {
        public override object Handle(DelChatIgnoreRequest @params)
        {
            bool YesOrNo = DatabaseManager.Account.DelBlockedUser(GetSession(), @params.ch, @params.uno);

            ResponsePacket response = new()
            {
                result = YesOrNo,
                id = BasePacket.Id
            };

            return response;
        }
    }

    public class DelChatIgnoreRequest
    {

        [JsonPropertyName("ch")]
        public int ch { get; set; }
        [JsonPropertyName("uno")]
        public string uno { get; set; }
    }

}
/*	// Token: 0x06005FC5 RID: 24517 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1302", true, true)]
	public void DelChatIgnore(int ch, string uno)
	{
	}

	// Token: 0x06005FC6 RID: 24518 RVA: 0x001AF6E0 File Offset: 0x001AD8E0
	private IEnumerator DelChatIgnoreResult(JsonRpcClient.Request request, bool result)
	{
		if (result)
		{
			int num = int.Parse(this._FindRequestProperty(request, "ch"));
			string text = this._FindRequestProperty(request, "uno");
			string text2 = string.Format("{0}_{1}", num, text);
			if (this.localUser.blockUsers.ContainsKey(text2))
			{
				NetworkAnimation.Instance.CreateFloatingText(string.Format(Localization.Get("7211"), this.localUser.blockUsers[text2].nickName));
				this.localUser.blockUsers.Remove(text2);
				UIManager.instance.RefreshOpenedUI();
			}
		}
		yield break;
	}*/