using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Host;
using StellarGK.Logic.Protocols;

namespace StellarGK.Packets.Handlers.Chat
{
    [Command(Id = CommandId.AddChatIgnore)]
    public class AddChatIgnore : BaseCommandHandler<AddChatIgnoreRequest>
    {
        public override object Handle(AddChatIgnoreRequest @params)
        {

            BlockUser blockUser = new()
            {
                channel = @params.ch,
                nickName = @params.nick,
                thumbnail = @params.thumb,
                uno = @params.uno,
            };

            bool YesOrNo = DatabaseManager.Account.AddBlockedUser(blockUser, GetSession());

            ResponsePacket response = new()
            {
                result = blockUser,
                id = BasePacket.Id
            };

            return response;
        }


    }

    public class AddChatIgnoreRequest
    {

        [JsonPropertyName("ch")]
        public int ch { get; set; }
        [JsonPropertyName("uno")]
        public string uno { get; set; }
        [JsonPropertyName("nick")]
        public string nick { get; set; }
        [JsonPropertyName("thumb")]
        public string thumb { get; set; }
    }

}





/*	// Token: 0x06005FC3 RID: 24515 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1301", true, true)]
	public void AddChatIgnore(int ch, string uno, string nick, string thumb)
	{
	}

	// Token: 0x06005FC4 RID: 24516 RVA: 0x001AF6BC File Offset: 0x001AD8BC
	private IEnumerator AddChatIgnoreResult(JsonRpcClient.Request request, Protocols.BlockUser result)
	{
		this.localUser.blockUsers.Add(string.Format("{0}_{1}", result.channel, result.uno), result);
		NetworkAnimation.Instance.CreateFloatingText(string.Format(Localization.Get("7205"), result.nickName));
		yield break;
	}*/