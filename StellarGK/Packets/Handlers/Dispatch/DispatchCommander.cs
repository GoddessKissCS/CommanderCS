namespace StellarGK.Packets.Handlers.Dispatch
{
    public class DispatchCommander
    {

    }
}
/*	// Token: 0x060060B5 RID: 24757 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7171", true, true)]
	public void DispatchCommander(int cid, int slot)
	{
	}

	// Token: 0x060060B6 RID: 24758 RVA: 0x001B0AC4 File Offset: 0x001AECC4
	private IEnumerator DispatchCommanderResult(JsonRpcClient.Request request, Dictionary<string, Protocols.DiapatchCommanderInfo> result)
	{
		RoLocalUser.SlotDispatchInfo slotDispatchInfo = new RoLocalUser.SlotDispatchInfo();
		foreach (KeyValuePair<string, Protocols.DiapatchCommanderInfo> keyValuePair in result)
		{
			slotDispatchInfo.SlotNum = keyValuePair.Key;
			slotDispatchInfo.dispatchCommanderInfo = keyValuePair.Value;
			if (!this.localUser.slotDispatchInfo.Contains(slotDispatchInfo))
			{
				this.localUser.slotDispatchInfo.Add(slotDispatchInfo);
			}
		}
		if (UIManager.instance.world.guild.dispatch != null)
		{
			UIManager.instance.world.guild.dispatch.SetDispatchList();
		}
		yield break;
	}

	// Token: 0x060060B7 RID: 24759 RVA: 0x001B0AE8 File Offset: 0x001AECE8
	private IEnumerator DispatchCommanderError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.CloseDispatchPopup();
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}*/