namespace StellarGK.Packets.Handlers.Dormitory
{
    public class ChangeDormitoryCommanderHead
    {
    }
}/*	// Token: 0x060061C6 RID: 25030 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8643", true, true)]
	public void ChangeDormitoryCommanderHead(string cid, string idx)
	{
	}

	// Token: 0x060061C7 RID: 25031 RVA: 0x001B2090 File Offset: 0x001B0290
	private IEnumerator ChangeDormitoryCommanderHeadResult(JsonRpcClient.Request request, Protocols.Dormitory.ChangeCommanderHeadResponse result)
	{
		foreach (KeyValuePair<string, Protocols.Dormitory.CommanderHeadData> keyValuePair in result.headData)
		{
			string key = keyValuePair.Key;
			RoDormitory.Item head = SingletonMonoBehaviour<DormitoryData>.Instance.characters[key].head;
			Dictionary<string, Protocols.Dormitory.CommanderHeadData>.Enumerator enumerator;
			KeyValuePair<string, Protocols.Dormitory.CommanderHeadData> keyValuePair2 = enumerator.Current;
			head.id = keyValuePair2.Value.headId;
			Message.Send<string>("Chr.Update.Costume", key);
		}
		yield break;
	}

	// Token: 0x060061C8 RID: 25032 RVA: 0x001B20AC File Offset: 0x001B02AC
	private IEnumerator ChangeDormitoryCommanderError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 85150)
		{
		}
		yield break;
	}*/