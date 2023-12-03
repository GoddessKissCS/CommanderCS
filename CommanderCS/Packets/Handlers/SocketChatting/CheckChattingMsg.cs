namespace CommanderCS.Packets.Handlers.SocketChatting
{
    public class CheckChattingMsg
    {
    }
}

/*	// Token: 0x06005FBF RID: 24511 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gkchat.flerogames.com/talk/server.php", "checkMsg", true, true)]
	public void CheckChattingMsg()
	{
	}

	// Token: 0x06005FC0 RID: 24512 RVA: 0x001AF674 File Offset: 0x001AD874
	private IEnumerator CheckChattingMsgResult(JsonRpcClient.Request request, string result, int guild, int channel)
	{
		UIManager.instance.world.mainCommand.chat.guildBadgeState = guild = 1;
		UIManager.instance.world.mainCommand.chat.channelBadgeState = channel = 1;
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/