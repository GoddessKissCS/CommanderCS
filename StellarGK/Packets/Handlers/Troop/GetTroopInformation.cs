namespace StellarGK.Packets.Handlers.Troop
{
    public class GetTroopInformation
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5119", true, true)]
	public void GetTroopInformation(int cid)
	{
	}

	// Token: 0x06005F4E RID: 24398 RVA: 0x001AED2C File Offset: 0x001ACF2C
	private IEnumerator GetTroopInformationResult(JsonRpcClient.Request request, Protocols.UserInformationResponse.Commander result)
	{
		this.localUser.AddOrRefreshCommanderFromNetwork(result);
		this._CheckReceiveTestData("GetTroopInfo");
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/