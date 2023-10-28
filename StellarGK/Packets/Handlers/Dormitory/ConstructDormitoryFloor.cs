namespace StellarGK.Packets.Handlers.Dormitory
{
    public class ConstructDormitoryFloor
    {
    }
}

/*	// Token: 0x060061A2 RID: 24994 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8602", true, true)]
	public void ConstructDormitoryFloor(string fno)
	{
	}

	// Token: 0x060061A3 RID: 24995 RVA: 0x001B1E28 File Offset: 0x001B0028
	private IEnumerator ConstructDormitoryFloorResult(JsonRpcClient.Request request, Protocols.Dormitory.ConstructFloorResponse result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		Message.Send("Update.Goods");
		Message.Send<Protocols.Dormitory.ConstructFloorResponse>("Room.Update.Build", result);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/