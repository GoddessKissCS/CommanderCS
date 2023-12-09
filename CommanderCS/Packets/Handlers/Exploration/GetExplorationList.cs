using CommanderCS.Host;
using CommanderCS.Protocols;

namespace CommanderCS.Packets.Handlers.Exploration
{
    [Packet(Id = Method.GetExplorationList)]
    public class GetExplorationList : BaseMethodHandler<GetExplorationListRequest>
    {
        public override object Handle(GetExplorationListRequest @params)
        {
            var user = GetUserGameProfile();

            ResponsePacket response = new()
            {
                Result = user.ExplorationData,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetExplorationListRequest
    {
    }
}

/*	// Token: 0x060060F3 RID: 24819 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3501", true, true)]
	public void GetExplorationList()
	{
	}

	// Token: 0x060060F4 RID: 24820 RVA: 0x001B0FB4 File Offset: 0x001AF1B4
	private IEnumerator GetExplorationListResult(JsonRpcClient.Request request, List<Protocols.ExplorationData> result)
	{
		for (int i = 0; i < result.Count; i++)
		{
			string worldMap = this.regulation.explorationDtbl[result[i].idx.ToString()].worldMap;
			this.localUser.explorationDtbl[worldMap].Set(result[i]);
		}
		yield break;
	}*/