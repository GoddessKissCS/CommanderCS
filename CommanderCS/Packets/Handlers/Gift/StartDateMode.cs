using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.Gift
{
	[Packet(Id = CommanderCSLibrary.Shared.Enum.Method.StartDateMode)]
    public class StartDateMode : BaseMethodHandler<StartDateModeRequest>
    {
        public override object Handle(StartDateModeRequest @params)
        {
			ResponsePacket response = new()
			{
				Id = BasePacket.Id,
				Result = new CommanderCSLibrary.Shared.Protocols.ResourceRecharge(),
			};


			// shouldnt need to be set

			return response;
        }
    }

	public class StartDateModeRequest
	{

	}
}

/*	// Token: 0x060060D3 RID: 24787 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4401", true, true)]
	public void StartDateMode()
	{
	}

	// Token: 0x060060D4 RID: 24788 RVA: 0x001B0D5C File Offset: 0x001AEF5C
	private IEnumerator StartDateModeResult(JsonRpcClient.Request request, Protocols.ResourceRecharge result)
	{
		yield break;
	}*/