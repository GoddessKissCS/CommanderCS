using CommanderCS.Host;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.InfinityBattle
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.SaveInfinityBattleDeck)]
    public class SaveInfinityBattleDeck : BaseMethodHandler<SaveInfinityBattleDeckRequest>
    {
        public override object Handle(SaveInfinityBattleDeckRequest @params)
        {
            DatabaseManager.GameProfile.UpdateInfinityBattleDeck(SessionId, @params.deck);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "success"
            };

            return response;
        }
    }

    public class SaveInfinityBattleDeckRequest
    {
        [JsonProperty("deck")]
        public JObject deck { get; set; }
    }
}

/*	// Token: 0x06006190 RID: 24976 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8702", true, true)]
	public void SaveInfinityBattleDeck(JObject deck)
	{
	}

	// Token: 0x06006191 RID: 24977 RVA: 0x001B1CF4 File Offset: 0x001AFEF4
	private IEnumerator SaveInfinityBattleDeckResult(JsonRpcClient.Request request, string result)
	{
		string text = this._FindRequestProperty(request, "deck");
		PlayerPrefs.SetString("InfinityBattleDeck", text);
		yield break;
	}

	// Token: 0x06006192 RID: 24978 RVA: 0x001B1D18 File Offset: 0x001AFF18
	private IEnumerator SaveInfinityBattleDeckError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/