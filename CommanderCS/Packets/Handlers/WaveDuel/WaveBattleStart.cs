using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.WaveBattleStart)]
    public class WaveBattleStart : BaseMethodHandler<WaveBattleStartRequest>
    {
        public override object Handle(WaveBattleStartRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            var resource = UserResources2Resource(User.Resources);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = resource,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
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

	// Token: 0x060060E7 RID: 24807 RVA: 0x001B0E94 File Offset: 0x001AF094
	private IEnumerator WaveBattleStartResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result is not null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		}
		Loading.Load(Loading.Battle);
		yield break;
	}*/
