using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using StellarGK.Host.Handlers.Nickname;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetEventBattleList)]
    public class GetEventBattleList : BaseCommandHandler<GetEventBattleListRequest>
    {

        public override string Handle(GetEventBattleListRequest @params)
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

            return JsonConvert.SerializeObject(response);
        }

    }
    public class GetEventBattleListRequest
    {

    }


}
