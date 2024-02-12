using CommanderCS.Host;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGK.Packets.Handlers.WorldDuel
{
	[Packet(Id = CommanderCSLibrary.Shared.Enum.Method.PvPStartWorldDuel)]
    public class PvPStartWorldDuel : BaseMethodHandler<PvPStartWorldDuelRequest>
    {
        public override object Handle(PvPStartWorldDuelRequest @params)
        {
			CommanderCSLibrary.Shared.Protocols.UserInformationResponse.BattleResult battleResult = new() { };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(battleResult),
            };

            return response;
        }
    }


	public class PvPStartWorldDuelRequest
	{
		[JsonProperty("type")]
		public int type { get; set; }

        [JsonProperty("retry")]
        public int retry { get; set; }

        [JsonProperty("deck")]
        public JObject deck { get; set; }

        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("checkSum")]
        public string checkSum { get; set; }

        [JsonProperty("info")]
        public JArray info { get; set; }

        [JsonProperty("result")]
        public JArray result { get; set; }
    }
}

/*	// Token: 0x06005F8B RID: 24459 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3740", true, true)]
	public void PvPStartWorldDuel(int type, int retry, JObject deck, int idx, string checkSum, JArray info, JArray result)
	{
	}

	// Token: 0x06005F8C RID: 24460 RVA: 0x001AF24C File Offset: 0x001AD44C
	private IEnumerator PvPStartWorldDuelResult(JsonRpcClient.Request request, object result)
	{
		BattleData _battleData = BattleData.Get();
		BattleData.Set(_battleData);
		Protocols.UserInformationResponse.BattleResult battleResult = null;
		if (_battleData = null)
		{
			yield break;
		}
		if (result = null)
		{
			yield break;
		}
		if (_battleData.type = EBattleType.WorldDuel)
		{
			battleResult = this._ConvertJObject<Protocols.UserInformationResponse.BattleResult>(result);
			_battleData.dualResult = battleResult;
			this.localUser.RefreshGoodsFromNetwork(battleResult.resource);
			this.localUser.RefreshPartFromNetwork(battleResult.partData);
			this.localUser.RefreshMedalFromNetwork(battleResult.medalData);
			this.localUser.RefreshFavorFromNetwork(battleResult.commanderFavor);
			this.localUser.RefreshItemFromNetwork(battleResult.eventResourceData);
			this.localUser.RefreshItemFromNetwork(battleResult.itemData);
		}
		UIWorldDuelInfoPopup popup = UIPopup.Create<UIWorldDuelInfoPopup>("WorldDuelInfoPopup");
		if (!_battleData.worldDuelReMatch)
		{
			popup.Init(this.localUser, this.localUser.worldDuelTarget);
		}
		else
		{
			popup.Init(this.localUser, this.localUser.worldDuelReMatchTarget);
		}
		popup.StartGameObjectDestroy();
		while (!popup.battleEnable)
		{
			yield return null;
		}
		Loading.Load(Loading.Battle);
		yield break;
	}*/