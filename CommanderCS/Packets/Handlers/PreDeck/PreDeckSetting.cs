using CommanderCS.Database;
using CommanderCS.Host;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CommanderCS.Packets.Handlers.PreDeck
{
	[Packet(Id = Method.PreDeckSetting)]
    public class PreDeckSetting : BaseMethodHandler<PreDeckSettingRequest>
    {
        public override object Handle(PreDeckSettingRequest @params)
        {
			var session = GetSession();

            var preDeckList = @params.list.ToObject<List<Protocols.UserInformationResponse.PreDeck>>();

            DatabaseManager.GameProfile.UpdatePreDeck(session, preDeckList);

            ResponsePacket response = new()
			{
				Id = BasePacket.Id,
				Result = "changed"
            };

			return response;
        }
    }


    public class PreDeckSettingRequest
    {
		[JsonProperty("list")]
		public JArray list {  get; set; }
    }

}

/*	// Token: 0x06006094 RID: 24724 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5220", false, true)]
	public void PreDeckSetting(JObject send)
	{
	}

	// Token: 0x06006095 RID: 24725 RVA: 0x001B0840 File Offset: 0x001AEA40
	private IEnumerator PreDeckSettingResult(JsonRpcClient.Request request, string result)
	{
		List<Protocols.UserInformationResponse.PreDeck> list = JsonConvert.DeserializeObject<List<Protocols.UserInformationResponse.PreDeck>>(this._FindRequestProperty(request, "list"));
		using (List<Protocols.UserInformationResponse.PreDeck>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Protocols.UserInformationResponse.PreDeck deck = enumerator.Current;
				Protocols.UserInformationResponse.PreDeck preDeck = this.localUser.preDeckList.Find((Protocols.UserInformationResponse.PreDeck row) => row.idx = deck.idx);
				if (preDeck != null)
				{
					preDeck.name = deck.name;
					preDeck.deckData = deck.deckData;
				}
			}
		}
		yield break;
	}*/