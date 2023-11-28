namespace CommanderCS.Packets.Handlers.Dispatch
{
    public class RecallDispatch
    {
    }
}

/*	// Token: 0x060060BB RID: 24763 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7173", true, true)]
	public void RecallDispatch(int slot)
	{
	}

	// Token: 0x060060BC RID: 24764 RVA: 0x001B0B44 File Offset: 0x001AED44
	private IEnumerator RecallDispatchResult(JsonRpcClient.Request request, Protocols.RecallCommander result)
	{
		if (result != null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.ResetDispatchPossible();
			DispatchRecallResultPopup dispatchRecallResultPopup = UIPopup.Create<DispatchRecallResultPopup>("resultPopup");
			if (UIManager.instance.world.guild.dispatch != null)
			{
				dispatchRecallResultPopup.SetPopup(result.runtime, result.getGold_time, result.getGold_engage);
			}
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x060060BD RID: 24765 RVA: 0x001B0B68 File Offset: 0x001AED68
	private IEnumerator RecallDispatchError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71203)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110010"));
		}
		else if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.CloseDispatchPopup();
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}*/