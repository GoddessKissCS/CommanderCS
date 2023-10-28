namespace StellarGK.Packets.Handlers.SocketChatting
{
    public class SendwaitChannelMsg
    {
    }
}

/*	// Token: 0x06005FBB RID: 24507 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gkchat.flerogames.com/talk/server.php", "waitChannel", true, true)]
	public void SendwaitChannelMsg()
	{
	}

	// Token: 0x06005FBC RID: 24508 RVA: 0x001AF62C File Offset: 0x001AD82C
	private IEnumerator SendwaitChannelMsgResult(JsonRpcClient.Request request, object result)
	{
		if (result == null)
		{
			yield break;
		}
		Protocols.ChattingInfo chattingInfo = this._ConvertJObject<Protocols.ChattingInfo>(result);
		if (chattingInfo.channelList != null)
		{
			for (int i = 0; i < chattingInfo.channelList.Count; i++)
			{
				if (chattingInfo.channelList[i].chatMsgData.record != null)
				{
					Protocols.ChattingInfo.ChattingData chattingData = new Protocols.ChattingInfo.ChattingData();
					chattingData.message = chattingInfo.channelList[i].message;
					this.localUser.chattingchannelList.Add(chattingData);
					chattingInfo.channelList[i].chatMsgData.data = Localization.Get("6143");
					chattingInfo.channelList[i].chatMsgData.record = null;
					this.localUser.chattingchannelList.Add(chattingInfo.channelList[i]);
				}
				else
				{
					this.localUser.chattingchannelList.Add(chattingInfo.channelList[i]);
				}
			}
		}
		while (this.localUser.chattingchannelList.Count > ConstValue.chatLimitCount)
		{
			if (this.localUser.chattingchannelList[0].chatMsgData.record != null)
			{
				this.localUser.chattingchannelList.RemoveAt(0);
				if (this.localUser.chattingchannelList.Count <= 0)
				{
					break;
				}
			}
			this.localUser.chattingchannelList.RemoveAt(0);
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/