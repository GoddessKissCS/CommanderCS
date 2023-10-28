namespace StellarGK.Packets.Handlers.Dormitory
{
    public class RemoveDormitoryDecoration
    {
    }
}/*	// Token: 0x060061BB RID: 25019 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8632", true, true)]
	public void RemoveDormitoryDecoration(string fno, int px, int py)
	{
	}

	// Token: 0x060061BC RID: 25020 RVA: 0x001B1FD0 File Offset: 0x001B01D0
	private IEnumerator RemoveDormitoryDecorationResult(JsonRpcClient.Request request, Protocols.Dormitory.ArrangeDecorationResponse result)
	{
		SingletonMonoBehaviour<DormitoryData>.Instance.dormitory.UpdateInvenData(EDormitoryItemType.Normal, result.invenNormal);
		SingletonMonoBehaviour<DormitoryData>.Instance.dormitory.UpdateInvenData(EDormitoryItemType.Advanced, result.invenAdvanced);
		Message.Send<string>("Inven.Update");
		yield break;
	}*/