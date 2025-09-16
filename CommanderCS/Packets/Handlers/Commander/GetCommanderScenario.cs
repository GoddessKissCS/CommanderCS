using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.GetCommanderScenario)]
    public class GetCommanderScenario : BaseMethodHandler<GetCommanderScenarioRequest>
    {
        public override object Handle(GetCommanderScenarioRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            ResponsePacket response = new()
            {
                Result = User.CommanderScenario,
                Id = BasePacket.Id
            };

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
		if (UIManager.instance.world is not null && UIManager.instance.world.existCommanderDetail && UIManager.instance.world.commanderDetail.isActive)
		{
			UIManager.instance.world.commanderDetail.InitScenarioList();
		}
		yield break;
	}*/