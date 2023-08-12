using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Commander
{
    [Command(Id = CommandId.GetCommanderScenario)]
    public class GetCommanderScenario : BaseCommandHandler<GetCommanderScenarioRequest>
    {
        public override object Handle(GetCommanderScenarioRequest @params)
        {
            ResponsePacket response = new();

            Dictionary<string, Dictionary<string, CommanderScenario>> result = new Dictionary<string, Dictionary<string, CommanderScenario>>();

            response.result = result;
            response.id = BasePacket.Id;

            return response;
        }

    }

    public class GetCommanderScenarioRequest
    {

    }
}
/*	// Token: 0x060060DD RID: 24797 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4309", true, true)]
	public void GetCommanderScenario()
	{
	}

	// Token: 0x060060DE RID: 24798 RVA: 0x001B0E04 File Offset: 0x001AF004
	private IEnumerator GetCommanderScenarioResult(JsonRpcClient.Request request, Dictionary<string, Dictionary<string, Protocols.CommanderScenario>> result)
	{
		this.localUser.sn_resultDictionary = result;
		if (UIManager.instance.world != null && UIManager.instance.world.existCommanderDetail && UIManager.instance.world.commanderDetail.isActive)
		{
			UIManager.instance.world.commanderDetail.InitScenarioList();
		}
		yield break;
	}*/