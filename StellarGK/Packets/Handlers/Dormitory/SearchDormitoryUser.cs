namespace StellarGK.Packets.Handlers.Dormitory
{
    public class SearchDormitoryUser
    {
    }
}

/*	// Token: 0x060061D2 RID: 25042 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8660", true, true)]
	public void SearchDormitoryUser(string nick)
	{
	}

	// Token: 0x060061D3 RID: 25043 RVA: 0x001B2164 File Offset: 0x001B0364
	private IEnumerator SearchDormitoryUserResult(JsonRpcClient.Request request, string result, List<Protocols.Dormitory.SearchUserInfo> slist)
	{
		MessageEvent.Search.Data data = new MessageEvent.Search.Data();
		data.type = EVisitType.Search;
		data.users = slist;
		if (slist.Count = 0)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81062"));
		}
		Message.Send<MessageEvent.Search.Data>("Search.Get.Users", data);
		yield break;
	}*/