namespace StellarGK.Packets.Handlers.InfinityBattle
{
    public class GetInfinityBattleDeck
    {

    }
}
/*	// Token: 0x0600618D RID: 24973 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8701", true, true)]
	public void GetInfinityBattleDeck()
	{
	}

	// Token: 0x0600618E RID: 24974 RVA: 0x001B1CC4 File Offset: 0x001AFEC4
	private IEnumerator GetInfinityBattleDeckResult(JsonRpcClient.Request request, string result, JObject deck)
	{
		if (deck != null)
		{
			PlayerPrefs.SetString("InfinityBattleDeck", JObject.FromObject(deck).ToString());
		}
		yield break;
	}

	// Token: 0x0600618F RID: 24975 RVA: 0x001B1CE0 File Offset: 0x001AFEE0
	private IEnumerator GetInfinityBattleDeckError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/