namespace CommanderCS.Packets.Handlers.Dormitory
{
    public class GetDormitoryGuildUser
    {
    }
}/*	// Token: 0x060061D9 RID: 25049 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8664", true, true)]
	public void GetDormitoryGuildUser()
	{
	}

	// Token: 0x060061DA RID: 25050 RVA: 0x001B21E4 File Offset: 0x001B03E4
	private IEnumerator GetDormitoryGuildUserResult(JsonRpcClient.Request request, string result, List<Protocols.Dormitory.SearchUserInfo> glist)
	{
		Message.Send<MessageEvent.Search.Data>("Search.Get.Users", new MessageEvent.Search.Data
		{
			type = EVisitType.Guild,
			users = glist
		});
		yield break;
	}*/