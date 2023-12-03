namespace CommanderCS.Packets.Handlers.Dormitory
{
    public class ArrangeDormitoryDecoration
    {
    }
}

/*	// Token: 0x060061B7 RID: 25015 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8630", true, true)]
	public void ArrangeDormitoryDecoration(string fno, string idx, int px, int py, int rt)
	{
	}

	// Token: 0x060061B8 RID: 25016 RVA: 0x001B1FA0 File Offset: 0x001B01A0
	private IEnumerator ArrangeDormitoryDecorationResult(JsonRpcClient.Request request, Protocols.Dormitory.ArrangeDecorationResponse result)
	{
		SingletonMonoBehaviour<DormitoryData>.Instance.dormitory.UpdateInvenData(EDormitoryItemType.Normal, result.invenNormal);
		SingletonMonoBehaviour<DormitoryData>.Instance.dormitory.UpdateInvenData(EDormitoryItemType.Advanced, result.invenAdvanced);
		Message.Send<string>("Inven.Update");
		yield break;
	}*/