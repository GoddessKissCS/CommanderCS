namespace CommanderCS.Packets.Handlers.Dormitory
{
    public class BuyDormitoryHeadCostume
    {
    }
}/*	// Token: 0x060061C4 RID: 25028 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8614", true, true)]
	public void BuyDormitoryHeadCostume(string idx)
	{
	}

	// Token: 0x060061C5 RID: 25029 RVA: 0x001B206C File Offset: 0x001B026C
	private IEnumerator BuyDormitoryHeadCostumeResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		this.localUser.RefreshRewardFromNetwork(result);
		Message.Send("Update.Goods");
		Message.Send("Inven.Update");
		yield break;
	}*/