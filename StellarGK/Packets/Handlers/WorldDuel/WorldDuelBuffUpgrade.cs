using Newtonsoft.Json;

namespace StellarGK.Packets.Handlers.WorldDuel
{
    public class WorldDuelBuffUpgrade
    {

    }
    public class WorldDuelBuffUpgradeRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
/*	// Token: 0x06006157 RID: 24919 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3605", true, true)]
	public void WorldDuelBuffUpgrade(string type)
	{
	}

	// Token: 0x06006158 RID: 24920 RVA: 0x001B1814 File Offset: 0x001AFA14
	private IEnumerator WorldDuelBuffUpgradeResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, Dictionary<string, int> buff)
	{
		if (!string.IsNullOrEmpty(result))
		{
			this.localUser.RefreshGoodsFromNetwork(rsoc);
			this.localUser.RefreshWorldDuelBuffFromNetwork(buff);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006159 RID: 24921 RVA: 0x001B1848 File Offset: 0x001AFA48
	private IEnumerator WorldDuelBuffUpgradeError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/