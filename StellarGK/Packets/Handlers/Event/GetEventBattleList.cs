using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetEventBattleList)]
    public class GetEventBattleList : BaseCommandHandler<GetEventBattleListRequest>
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
                result = battleInfos,
                id = BasePacket.Id
            };

            return response;
        }

    }
    public class GetEventBattleListRequest
    {

    }


}
