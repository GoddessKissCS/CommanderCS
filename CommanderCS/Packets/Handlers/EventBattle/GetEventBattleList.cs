﻿using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Event
{
    [Packet(Id = Method.GetEventBattleList)]
    public class GetEventBattleList : BaseMethodHandler<GetEventBattleListRequest>
    {
        public override object Handle(GetEventBattleListRequest @params)
        {
            List<EventBattleInfo> battleInfos = new();

            EventBattleInfo @event = new()
            {
                idx = "999",
                remain = 1,
                rewardCount = 1,
            };

            battleInfos.Add(@event);

            ResponsePacket response = new()
            {
                Result = battleInfos,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetEventBattleListRequest
    {
    }
}

/*	// Token: 0x06006117 RID: 24855 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2301", true, true)]
	public void GetEventBattleList()
	{
	}

	// Token: 0x06006118 RID: 24856 RVA: 0x001B1290 File Offset: 0x001AF490
	private IEnumerator GetEventBattleListResult(JsonRpcClient.Request request, List<Protocols.EventBattleInfo> result)
	{
		if (result.Count > 0)
		{
			UIEventBattleListPopup uieventBattleListPopup = UIPopup.Create<UIEventBattleListPopup>("EventBattleListPopup");
			uieventBattleListPopup.Init(result);
		}
		yield break;
	}*/