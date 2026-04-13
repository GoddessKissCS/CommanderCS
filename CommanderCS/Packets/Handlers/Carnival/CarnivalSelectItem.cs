using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Carnival
{
    [Packet(Id = Method.CarnivalSelectItem)]
    public class CarnivalSelectItem : BaseMethodHandler<CarnivalSelectItemRequest>
    {
        public override object Handle(CarnivalSelectItemRequest request)
        {
            GameProfileScheme user = GetUserGameProfile();

            Dictionary<string, Dictionary<string, CarnivalList.ProcessData>> carnivalProcessList = [];

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = new JObject
                {
                    ["ctnt"] = JToken.FromObject(carnivalProcessList),
                },
            };

            return response;
        }
    }

    public class CarnivalSelectItemRequest
    {
        [JsonProperty("ctid")]
        public int ctid { get; set; }

        [JsonProperty("cidx")]
        public int cidx { get; set; }

        [JsonProperty("ridx")]
        public int ridx { get; set; }
    }
}

/*	// Token: 0x060060C5 RID: 24773 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6244", true, true)]
	public void CarnivalSelectItem(int ctid, int cidx, int ridx)
	{
	}

	// Token: 0x060060C6 RID: 24774 RVA: 0x001B0C24 File Offset: 0x001AEE24
	private IEnumerator CarnivalSelectItemResult(JsonRpcClient.Request request, string result, Dictionary<string, Dictionary<string, Protocols.CarnivalList.ProcessData>> ctnt)
	{
		if (result !=null)
		{
			this.localUser.RefreshCarnivalFromNetwork(ctnt);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x060060C7 RID: 24775 RVA: 0x001B0C50 File Offset: 0x001AEE50
	private IEnumerator CarnivalSelectItemError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 20001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("5065"));
		}
		yield break;
	}*/
