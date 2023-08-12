namespace StellarGK.Packets.Handlers.Replay
{
    public class GetReplayList
    {

    }
}
/*	// Token: 0x06005FE3 RID: 24547 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3132", true, true)]
	public void GetReplayList(ERePlayType type, ERePlaySubType stype, int ver)
	{
	}

	// Token: 0x06005FE4 RID: 24548 RVA: 0x001AF928 File Offset: 0x001ADB28
	private IEnumerator GetReplayListResult(JsonRpcClient.Request request, List<Protocols.RecordInfo> result)
	{
		if (result == null)
		{
			yield break;
		}
		UIManager.World world = UIManager.instance.world;
		ERePlayType erePlayType = (ERePlayType)this._ConvertStringToInt(this._FindRequestProperty(request, "type"));
		if (erePlayType == ERePlayType.Challenge || erePlayType == ERePlayType.WaveDuel)
		{
			ERePlaySubType erePlaySubType = (ERePlaySubType)this._ConvertStringToInt(this._FindRequestProperty(request, "stype"));
			if (erePlaySubType == ERePlaySubType.Attack)
			{
				this.localUser.atkRecordList = result;
			}
			else
			{
				this.localUser.defRecordList = result;
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/