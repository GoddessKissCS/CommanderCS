namespace StellarGK.Packets.Handlers.Chat
{
    public class SendWaitChatMsg
    {

    }
}
/*	// Token: 0x06005FB9 RID: 24505 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gkchat.flerogames.com/talk/server.php", "wait", true, true)]
	public void SendWaitChatMsg(int date, int guild)
	{
	}

	// Token: 0x06005FBA RID: 24506 RVA: 0x001AF608 File Offset: 0x001AD808
	private IEnumerator SendWaitChatMsgResult(JsonRpcClient.Request request, Protocols.ChattingInfo result)
	{
		if (result.whisperList != null)
		{
			for (int i = 0; i < result.whisperList.Count; i++)
			{
				this.localUser.chattingWhisperList.Add(result.whisperList[i]);
			}
		}
		if (result.guildList != null)
		{
			for (int j = 0; j < result.guildList.Count; j++)
			{
				this.localUser.chattingGuildList.Add(result.guildList[j]);
			}
		}
		if (result.channelList != null)
		{
			for (int k = 0; k < result.channelList.Count; k++)
			{
				if (result.channelList[k].chatMsgData.record != null)
				{
					Protocols.ChattingInfo.ChattingData chattingData = new Protocols.ChattingInfo.ChattingData();
					chattingData.message = result.channelList[k].message;
					this.localUser.chattingchannelList.Add(chattingData);
					result.channelList[k].chatMsgData.data = Localization.Get("6143");
					result.channelList[k].chatMsgData.record = null;
					this.localUser.chattingchannelList.Add(result.channelList[k]);
				}
				else
				{
					this.localUser.chattingchannelList.Add(result.channelList[k]);
				}
			}
		}
		this.localUser.chattingDate = result.time;
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/