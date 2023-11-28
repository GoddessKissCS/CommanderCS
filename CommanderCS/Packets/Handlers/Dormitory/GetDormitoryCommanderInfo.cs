namespace CommanderCS.Packets.Handlers.Dormitory
{
    public class GetDormitoryCommanderInfo
    {
    }
}/*	// Token: 0x060061BD RID: 25021 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8640", true, true)]
	public void GetDormitoryCommanderInfo()
	{
	}

	// Token: 0x060061BE RID: 25022 RVA: 0x001B1FEC File Offset: 0x001B01EC
	private IEnumerator GetDormitoryCommanderInfoResult(JsonRpcClient.Request request, Protocols.Dormitory.GetDormitoryCommanderInfoResponse result)
	{
		this.localUser.dormitory.Set(result.commanderData);
		if (result.headData != null)
		{
			this.localUser.dormitory.UpdateHeadData(result.headData);
		}
		Message.Send("Chr.Get");
		yield break;
	}*/