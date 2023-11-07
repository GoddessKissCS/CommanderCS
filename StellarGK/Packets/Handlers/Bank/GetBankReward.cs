namespace StellarGK.Packets.Handlers.Bank
{
    public class GetBankReward
    {
    }
}

/*	// Token: 0x06005FCC RID: 24524 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5303", true, true)]
	public void GetBankReward()
	{
	}

	// Token: 0x06005FCD RID: 24525 RVA: 0x001AF770 File Offset: 0x001AD970
	private IEnumerator GetBankRewardResult(JsonRpcClient.Request request, string result, long gold)
	{
		this.localUser.gold = (int)Math.Min(gold, 2147483647L);
		UIManager.instance.world.metroBank.InitUI();
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/