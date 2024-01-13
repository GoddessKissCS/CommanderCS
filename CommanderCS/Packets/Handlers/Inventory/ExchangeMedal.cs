using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Inventory
{
    //[Packet(Id = Method.ExchangeMedal)]
    public class ExchangeMedal : BaseMethodHandler<ExchangeMedalRequest>
    {
        public override object Handle(ExchangeMedalRequest @params)
        {
            var user = GetUserGameProfile();

            user.CommanderData.TryGetValue("" + @params.cid, out var commanderData);
            user.UserInventory.medalData.TryGetValue("" + @params.cid, out int medal);

            commanderData.medl += @params.amnt;
            medal += @params.amnt;

            // AND THEN WE NEED TO SUBSTRACT THE EXCHANGEMEDALS FROM THE USER

            return "";
        }
    }

    public class ExchangeMedalRequest
    {
        [JsonProperty("amnt")]
        public int amnt { get; set; }

        [JsonProperty("cid")]
        public int cid { get; set; }
    }
}

/*	// Token: 0x06006096 RID: 24726 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5221", true, true)]
	public void ExchangeMedal(int amnt, int cid)
	{
	}

	// Token: 0x06006097 RID: 24727 RVA: 0x001B0864 File Offset: 0x001AEA64
	private IEnumerator ExchangeMedalResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		this.localUser.FromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		UITranscendencePopup uitranscendencePopup = UnityEngine.Object.FindObjectOfType(typeof(UITranscendencePopup)) as UITranscendencePopup;
		if (uitranscendencePopup != null)
		{
			uitranscendencePopup.Set(0);
		}
		yield break;
	}*/