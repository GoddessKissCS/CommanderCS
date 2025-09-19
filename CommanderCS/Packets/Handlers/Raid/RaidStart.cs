using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Packets;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Raid
{
	[Packet(Id = Method.RaidStart)]
    public class RaidStart : BaseMethodHandler<RaidStartRequest>
    {
		public override object Handle(RaidStartRequest @params)
		{
            GameProfileScheme User = GetUserGameProfile();

            WorldMapStageStartResponse wmssr = new();

            //TODO: look at the stage and then the rewards it can gen
            List<RewardInfo.RewardData> test = [];


            //- the key so you know you started the raid

            wmssr.reward = test;


            wmssr.rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = wmssr
            };

            return response;
        }
    }

    public class RaidStartRequest
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("deck")]
        public JObject Deck { get; set; }

        [JsonProperty("gdp")]
        public JObject Gdp { get; set; }

        [JsonProperty("ucash")]
        public int Ucash { get; set; }

        [JsonProperty("bid")]
        public int bid { get; set; }

        [JsonProperty("np")]
        public int Np { get; set; }
    }
}

/*	// Token: 0x06005FD4 RID: 24532 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3734", true, true)]
	public void RaidStart(int type, JObject deck, JObject gdp, int ucash, int bid, int np)
	{
	}

	// Token: 0x06005FD5 RID: 24533 RVA: 0x001AF7F0 File Offset: 0x001AD9F0
	private IEnumerator RaidStartResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc)
	{
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x06005FD6 RID: 24534 RVA: 0x001AF81C File Offset: 0x001ADA1C
	private IEnumerator RaidStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 70009)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7044"));
		}
		yield break;
	}*/