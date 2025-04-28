using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Defender
{
    [Packet(Id = Method.DefenderSetting)]
    public class DefenderSetting : BaseMethodHandler<DefenderSettingRequest>
    {
        public override object Handle(DefenderSettingRequest @params)
        {
            Dictionary<string, string> deck = @params.deck.ToObject<Dictionary<string, string>>();

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "",
            };

            bool didDefenderDeckUpdate = DatabaseManager.GameProfile.UpdatePvPDefenderDeck(SessionId, deck);

            if (didDefenderDeckUpdate)
            {
                response.Result = "True";

                return response;
            }
            response.Result = "False";
            return response;
        }
    }

    public class DefenderSettingRequest
    {
        [JsonProperty("deck")]
        public JObject deck { get; set; }
    }
}

/*	// Token: 0x06005F8F RID: 24463 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3228", true, true)]
	public void DefenderSetting(JObject deck)
	{
	}

	// Token: 0x06005F90 RID: 24464 RVA: 0x001AF29C File Offset: 0x001AD49C
	private IEnumerator DefenderSettingResult(JsonRpcClient.Request request, string result)
	{
		if (result.Equals("True"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(this._FindRequestProperty(request, "deck"));
			this.localUser.RefreshDefenderTroop(dictionary);
			UIManager.instance.world.readyBattle.CloseAnimation();
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/