namespace CommanderCS.Packets.Handlers.Dormitory
{
    public class FinishConstructDormitoryFloor
    {
    }
}

/*	// Token: 0x060061A4 RID: 24996 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8603", true, true)]
	public void FinishConstructDormitoryFloor(string fno, int imm)
	{
	}

	// Token: 0x060061A5 RID: 24997 RVA: 0x001B1E4C File Offset: 0x001B004C
	private IEnumerator FinishConstructDormitoryFloorResult(JsonRpcClient.Request request, Protocols.Dormitory.FinishConstructFloorResponse result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		Message.Send("Update.Goods");
		Message.Send<Protocols.Dormitory.FinishConstructFloorResponse>("Room.Update.Build", result);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/