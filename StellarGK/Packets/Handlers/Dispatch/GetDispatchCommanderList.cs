namespace StellarGK.Packets.Handlers.Dispatch
{
    public class GetDispatchCommanderList
    {

    }
}
/*	// Token: 0x060060B8 RID: 24760 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7170", true, true)]
	public void GetDispatchCommanderList()
	{
	}

	// Token: 0x060060B9 RID: 24761 RVA: 0x001B0B04 File Offset: 0x001AED04
	private IEnumerator GetDispatchCommanderListResult(JsonRpcClient.Request request, Dictionary<string, Protocols.DiapatchCommanderInfo> result)
	{
		if (result != null)
		{
			this.localUser.slotDispatchInfo.Clear();
			foreach (KeyValuePair<string, Protocols.DiapatchCommanderInfo> keyValuePair in result)
			{
				RoLocalUser.SlotDispatchInfo slotDispatchInfo = new RoLocalUser.SlotDispatchInfo();
				slotDispatchInfo.SlotNum = keyValuePair.Key;
				slotDispatchInfo.dispatchCommanderInfo = keyValuePair.Value;
				this.localUser.slotDispatchInfo.Add(slotDispatchInfo);
			}
			if (UIManager.instance.world.guild.dispatch != null)
			{
				UIManager.instance.world.guild.dispatch.SetDispatchList();
			}
		}
		yield break;
	}

	// Token: 0x060060BA RID: 24762 RVA: 0x001B0B28 File Offset: 0x001AED28
	private IEnumerator GetDispatchCommanderListError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.CloseDispatchPopup();
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}
*/