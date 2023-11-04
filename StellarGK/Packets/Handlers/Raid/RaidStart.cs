namespace StellarGK.Packets.Handlers.Raid
{
    public class RaidStart
    {
    }
}

/*	// Token: 0x06005FD4 RID: 24532 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3734", true, true)]
	public void RaidStart(int type, JObject deck, JObject gdp, int ucash, int bid, int np)
	{
	}

	// Token: 0x06005FD5 RID: 24533 RVA: 0x001AF7F0 File Offset: 0x001AD9F0
	private IEnumerator RaidStartResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc)
	{
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x06005FD6 RID: 24534 RVA: 0x001AF81C File Offset: 0x001ADA1C
	private IEnumerator RaidStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 70009)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7044"));
		}
		yield break;
	}*/