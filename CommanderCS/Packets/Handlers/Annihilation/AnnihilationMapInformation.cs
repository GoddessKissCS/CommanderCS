using CommanderCS.Enum.Packet;
using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.Annihilation
{
    [Packet(Id = Method.AnnihilationMapInformation)]
    public class AnnihilationMapInformation : BaseMethodHandler<AnnihilationMapInformationRequest>
    {
        public override object Handle(AnnihilationMapInformationRequest @params)
        {
            return "{}";
        }
    }

    public class AnnihilationMapInformationRequest
    {
    }
}

/*	// Token: 0x06006017 RID: 24599 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7301", true, true)]
	public void AnnihilationMapInformation()
	{
	}

	// Token: 0x06006018 RID: 24600 RVA: 0x001AFDB8 File Offset: 0x001ADFB8
	private IEnumerator AnnihilationMapInformationResult(JsonRpcClient.Request request, List<Protocols.ScrambleMapInformationResponse> result)
	{
		if (result == null)
		{
			yield break;
		}
		yield break;
	}*/