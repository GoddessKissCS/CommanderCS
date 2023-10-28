namespace StellarGK.Packets.Handlers.Unit
{
    public class UnitUpgrade
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4304", true, true)]
	public void UnitUpgrade(int idx)
	{
	}

	// Token: 0x06005F4B RID: 24395 RVA: 0x001AECE4 File Offset: 0x001ACEE4
	private IEnumerator UnitUpgradeResult(JsonRpcClient.Request request, Protocols.UnitUpgradeResponse result)
	{
		this.localUser.gold = result.goodsInfo.gold;
		this.localUser.blueprintArmy = result.goodsInfo.blueprintArmy;
		foreach (Protocols.UserInformationResponse.PartData partData in result.partData)
		{
			this.localUser.SetUserPart(partData.idx, partData.count);
		}
		foreach (KeyValuePair<string, Protocols.UnitUpgradeResponse.Unit> keyValuePair in result.unitInfo)
		{
			Protocols.UnitUpgradeResponse.Unit value = keyValuePair.Value;
			RoUnit roUnit = this.localUser.FindUnit(keyValuePair.Key);
			roUnit.level = value.level;
			UIManager.instance.world.unitUpgradeComplete.Init(roUnit);
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F4C RID: 24396 RVA: 0x001AED08 File Offset: 0x001ACF08
	private IEnumerator UnitUpgradeError(JsonRpcClient.Request request, string result, int code, string message)
	{
		UISimplePopup.CreateDebugOK(code.ToString(), message, "확인");
		yield break;
	}*/