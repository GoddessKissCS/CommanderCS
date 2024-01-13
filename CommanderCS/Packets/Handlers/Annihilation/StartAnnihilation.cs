using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Annihilation
{
    [Packet(Id = Method.StartAnnihilation)]
    public class StartAnnihilation : BaseMethodHandler<StartAnnihilationRequest>
    {
        public override object Handle(StartAnnihilationRequest @params)
        {
            return "{}";
        }
    }

    public class StartAnnihilationRequest
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("stage")]
        public int stage { get; set; }
    }
}

/*	// Token: 0x0600601B RID: 24603 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3736", true, true)]
	public void StartAnnihilation(int type, int cid, int stage)
	{
	}

	// Token: 0x0600601C RID: 24604 RVA: 0x001AFE00 File Offset: 0x001AE000
	private IEnumerator StartAnnihilationResult(JsonRpcClient.Request request, string result)
	{
		if (result == null)
		{
			yield break;
		}
		Loading.Load(Loading.Battle);
		yield break;
	}*/