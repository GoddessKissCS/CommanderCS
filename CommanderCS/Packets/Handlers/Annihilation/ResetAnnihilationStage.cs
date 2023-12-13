using CommanderCS.Enum;
using CommanderCS.Enum.Packet;
using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Annihilation
{
    [Packet(Id = Method.ResetAnnihilationStage)]
    public class ResetAnnihilationStage : BaseMethodHandler<ResetAnnihilationStageRequest>
    {
        public override object Handle(ResetAnnihilationStageRequest @params)
        {
            return "{}";
        }
    }

    public class ResetAnnihilationStageRequest
    {
        [JsonProperty("mode")]
        public AnnihilationMode mode { get; set; }
    }
}

/*	// Token: 0x060060AD RID: 24749 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3237", true, true)]
	public void ResetAnnihilationStage(AnnihilationMode mode)
	{
	}

	// Token: 0x060060AE RID: 24750 RVA: 0x001B0A3C File Offset: 0x001AEC3C
	private IEnumerator ResetAnnihilationStageResult(JsonRpcClient.Request request, Protocols.AnnihilationMapInfo result)
	{
		this.localUser.ResetAdvancePossible();
		UIAnnihilationMap annihilationMap = UIManager.instance.world.annihilationMap;
		annihilationMap.isPlay = false;
		annihilationMap.isPlayAdvanceParty = false;
		annihilationMap.isReset = true;
		if (PlayerPrefs.HasKey("MercenaryDeck"))
		{
			PlayerPrefs.DeleteKey("MercenaryDeck");
		}
		yield break;
	}*/