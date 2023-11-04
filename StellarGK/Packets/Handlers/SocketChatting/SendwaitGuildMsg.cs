namespace StellarGK.Packets.Handlers.SocketChatting
{
    public class SendwaitGuildMsg
    {
    }
}

/*	// Token: 0x06005FBD RID: 24509 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gkchat.flerogames.com/talk/server.php", "waitGuild", true, true)]
	public void SendwaitGuildMsg()
	{
	}

	// Token: 0x06005FBE RID: 24510 RVA: 0x001AF650 File Offset: 0x001AD850
	private IEnumerator SendwaitGuildMsgResult(JsonRpcClient.Request request, object result)
	{
		if (result = null)
		{
			yield break;
		}
		Protocols.ChattingInfo chattingInfo = this._ConvertJObject<Protocols.ChattingInfo>(result);
		if (chattingInfo.guildList != null)
		{
			for (int i = 0; i < chattingInfo.guildList.Count; i++)
			{
				this.localUser.chattingGuildList.Add(chattingInfo.guildList[i]);
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/