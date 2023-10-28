namespace StellarGK.Packets.Handlers.Commander
{
    public class ChangeCommanderCostume
    {
    }
}

/*	// Token: 0x0600609A RID: 24730 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4305", true, true)]
	public void ChangeCommanderCostume(int cid, int cos)
	{
	}

	// Token: 0x0600609B RID: 24731 RVA: 0x001B08B4 File Offset: 0x001AEAB4
	private IEnumerator ChangeCommanderCostumeResult(JsonRpcClient.Request request, string result)
	{
		string text = this._FindRequestProperty(request, "cid");
		string text2 = this._FindRequestProperty(request, "cos");
		if (this.regulation.FindCostumeData(int.Parse(this.localUser.thumbnailId)).cid == int.Parse(text))
		{
			this.localUser.thumbnailId = text2;
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/