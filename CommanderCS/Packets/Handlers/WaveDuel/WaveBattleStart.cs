using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    public class WaveBattleStart
    {
    }

    public class WaveBattleStartRequest
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("deck")]
        public JObject Deck { get; set; }

        [JsonProperty("gdp")]
        public JObject Gdp { get; set; }

        [JsonProperty("ucash")]
        public int Ucash { get; set; }

        [JsonProperty("idx")]
        public int Idx { get; set; }

        [JsonProperty("np")]
        public int Np { get; set; }
    }
}

/*	// Token: 0x060060E6 RID: 24806 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3730", true, true)]
	public void WaveBattleStart(int type, JObject deck, JObject gdp, int ucash, int idx, int np)
	{
	}

	// Token: 0x060060E7 RID: 24807 RVA: 0x001B0EB0 File Offset: 0x001AF0B0
	private IEnumerator WaveBattleStartResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result is not null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		}
		Loading.Load(Loading.Battle);
		yield break;
	}*/