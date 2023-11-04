namespace StellarGK.Packets.Handlers.Event
{
    public class EventBattleGachaReset
    {
    }
}

/* 	// Token: 0x0600613F RID: 24895 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2312", true, true)]
	public void EventBattleGachaReset(int eidx)
	{
	}

	// Token: 0x06006140 RID: 24896 RVA: 0x001B1610 File Offset: 0x001AF810
	private IEnumerator EventBattleGachaResetResult(JsonRpcClient.Request request, Protocols.EventBattleGachaInfo result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "eidx"));
		if (result != null && UIManager.instance.world != null)
		{
			UIManager.instance.world.eventBattle.SetEventGachaData(result);
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("11000004"));
		}
		yield break;
	}

	// Token: 0x06006141 RID: 24897 RVA: 0x001B163C File Offset: 0x001AF83C
	private IEnumerator EventBattleGachaResetError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 70210)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("6600"));
			yield break;
		}
		base.StartCoroutine(this.OnJsonRpcRequestError(request, result, code));
		yield break;
	}*/