namespace StellarGK.Packets.Handlers.Replay
{
    public class GetRecordList
    {

    }
}
/*	// Token: 0x06005FE8 RID: 24552 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3131", true, true)]
	public void GetRecordList(int type, int ver)
	{
	}

	// Token: 0x06005FE9 RID: 24553 RVA: 0x001AF994 File Offset: 0x001ADB94
	private IEnumerator GetRecordListResult(JsonRpcClient.Request request, List<Protocols.RecordInfo> result)
	{
		if (result == null)
		{
			yield break;
		}
		UIManager.World world = UIManager.instance.world;
		int num = this._ConvertStringToInt(this._FindRequestProperty(request, "type"));
		if (num == 6 || num == 17)
		{
			this.localUser.atkRecordList = result;
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/