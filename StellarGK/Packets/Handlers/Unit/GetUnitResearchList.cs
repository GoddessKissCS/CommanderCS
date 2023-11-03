using StellarGK.Host;
using StellarGKLibrary.Protocols;

namespace StellarGK.Packets.Handlers.Unit
{
    [Packet(Id = Method.GetUnitResearchList)]
    public class GetUnitResearchList : BaseMethodHandler<GetUnitResearchListRequest>
    {
        public override object Handle(GetUnitResearchListRequest @params)
        {
            ResponsePacket response = new()
            {
                Result = null,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetUnitResearchListRequest
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4303", true, true)]
	public void GetUnitResearchList()
	{
	}

	// Token: 0x06005F48 RID: 24392 RVA: 0x001AEC9C File Offset: 0x001ACE9C
	private IEnumerator GetUnitResearchListResult(JsonRpcClient.Request request, List<Protocols.GetUnitResearchListResponse> result)
	{
		result.ForEach(delegate(Protocols.GetUnitResearchListResponse data)
		{
			RoUnit roUnit = this.localUser.FindUnit(data.id.ToString());
			roUnit.trainingTime.SetByDuration((double)data.remainTime);
		});
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F49 RID: 24393 RVA: 0x001AECC0 File Offset: 0x001ACEC0
	private IEnumerator GetUnitResearchListError(JsonRpcClient.Request request, string result, int code, string message)
	{
		UISimplePopup.CreateDebugOK(code.ToString(), message, "확인");
		yield break;
	}*/