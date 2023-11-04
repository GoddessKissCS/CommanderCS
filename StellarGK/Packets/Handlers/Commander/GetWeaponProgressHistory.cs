namespace StellarGK.Packets.Handlers.Commander
{
    public class GetWeaponProgressHistory
    {
    }
}

/*	// Token: 0x06006187 RID: 24967 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8520", true, true)]
	public void GetWeaponProgressHistory(int type)
	{
	}

	// Token: 0x06006188 RID: 24968 RVA: 0x001B1C44 File Offset: 0x001AFE44
	private IEnumerator GetWeaponProgressHistoryResult(JsonRpcClient.Request request, string result, List<List<string>> recp)
	{
		int num = int.Parse(this._FindRequestProperty(request, "type"));
		if (!this.localUser.weaponHistory.ContainsKey(num))
		{
			this.localUser.weaponHistory.Add(num, recp);
		}
		if (UIManager.instance.world.weaponResearch.inProgress.historyPopup = null)
		{
			UIManager.instance.world.weaponResearch.inProgress.historyPopup = UIPopup.Create<UIWeaponProgressHistoryPopup>("WeaponProgressHistoryPopup");
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006189 RID: 24969 RVA: 0x001B1C70 File Offset: 0x001AFE70
	private IEnumerator GetWeaponProgressHistoryError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/