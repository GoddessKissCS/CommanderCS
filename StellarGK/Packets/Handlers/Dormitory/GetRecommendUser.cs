namespace StellarGK.Packets.Handlers.Dormitory
{
    public class GetRecommendUser
    {

    }
}/*	// Token: 0x060061D0 RID: 25040 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8665", true, true)]
	public void GetRecommendUser()
	{
	}

	// Token: 0x060061D1 RID: 25041 RVA: 0x001B2148 File Offset: 0x001B0348
	private IEnumerator GetRecommendUserResult(JsonRpcClient.Request request, string result, List<Protocols.Dormitory.SearchUserInfo> slist)
	{
		Message.Send<MessageEvent.Search.Data>("Search.Get.Users", new MessageEvent.Search.Data
		{
			type = EVisitType.Search,
			users = slist
		});
		yield break;
	}*/