namespace StellarGK.Packets.Handlers.Dormitory
{
    public class GetDormitoryPointAll
    {
    }
}/*	// Token: 0x060061CE RID: 25038 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8651", true, true)]
	public void GetDormitoryPointAll(string fno)
	{
	}

	// Token: 0x060061CF RID: 25039 RVA: 0x001B2124 File Offset: 0x001B0324
	private IEnumerator GetDormitoryPointAllResult(JsonRpcClient.Request request, Protocols.Dormitory.GetPointAllResponse result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		Message.Send("Update.Goods");
		Message.Send<bool>("Room.Update.PointState", result.pointState);
		if (result.reaminData != null)
		{
			foreach (KeyValuePair<string, Protocols.Dormitory.CommanderRaminData> keyValuePair in result.reaminData)
			{
				string key = keyValuePair.Key;
				TimeData remain = SingletonMonoBehaviour<DormitoryData>.Instance.characters[key].remain;
				Dictionary<string, Protocols.Dormitory.CommanderRaminData>.Enumerator enumerator;
				KeyValuePair<string, Protocols.Dormitory.CommanderRaminData> keyValuePair2 = enumerator.Current;
				remain.SetByDuration(keyValuePair2.Value.remain);
				Message.Send<string>("Chr.Update.RewardRemain", key);
			}
		}
		yield break;
	}*/