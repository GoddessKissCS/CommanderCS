using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.InfinityBattle
{
    [Packet(Id = Method.GetInfinityBattleDeck)]
    public class GetInfinityBattleDeck : BaseMethodHandler<GetInfinityBattleDeckRequest>
    {
        public override object Handle(GetInfinityBattleDeckRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = null,
            };

            GetInfinityBattleDeckResponse battleDeckResponse = new()
            {
            };

            if (User.DefenderDeck.InfinityBattleDeck is not null)
            {
                battleDeckResponse.deck = User.DefenderDeck.InfinityBattleDeck;

                response.Result = battleDeckResponse;

                return response;
            }

            return response;
        }
    }

    public class GetInfinityBattleDeckRequest
    {
    }

    public class GetInfinityBattleDeckResponse
    {
        [JsonProperty("deck")]
        public JObject deck { get; set; }
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
		if (deck is not null)
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