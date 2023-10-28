namespace StellarGK.Packets.Handlers.Commander
{
    public class BuyCommanderCostume
    {
    }
}

/*	// Token: 0x06006098 RID: 24728 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4306", true, true)]
	public void BuyCommanderCostume(int cid, int cos)
	{
	}

	// Token: 0x06006099 RID: 24729 RVA: 0x001B0888 File Offset: 0x001AEA88
	private IEnumerator BuyCommanderCostumeResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		string text = this._FindRequestProperty(request, "cid");
		int num = int.Parse(this._FindRequestProperty(request, "cos"));
		RoCommander roCommander = this.localUser.FindCommander(text);
		if (!roCommander.haveCostumeList.Contains(num))
		{
			roCommander.haveCostumeList.Add(num);
		}
		if (roCommander.state == ECommanderState.Undefined)
		{
			this.localUser.AddDonHaveCommCostume(text, num);
		}
		this.localUser.FromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/