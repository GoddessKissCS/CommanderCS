using CommanderCS.Library.Shared;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Dispatch
{
    [Packet(Id = Method.GetDispatchCommanderListFromLogin)]
    public class GetDispatchCommanderListFromLogin : BaseMethodHandler<GetDispatchCommanderListFromLoginRequest>
    {
        public override object Handle(GetDispatchCommanderListFromLoginRequest @params)
        {
            Dictionary<string, DiapatchCommanderInfo> dispatchedcommanders = [];

            if (User.DispatchedCommanders is not null)
            {
                foreach (var item in User.DispatchedCommanders)
                {
                    int runtime = (int)TimeManager.GetTimeDifferenceInHours(item.Value.DispatchTime);
                    int dispatchTime = (int)TimeManager.GetTimeDifference(item.Value.DispatchTime);

                    int gold = 0;

                    int engageCount = item.Value.engageCnt;

                    string stringedItem = item.Value.cid.ToString();

                    User.CommanderData.TryGetValue(stringedItem, out var commander);

                    if (runtime >= 1)
                    {
                        gold = runtime * GetDispatchGold(commander.__level, commander.__cls, commander.__rank);
                    }

                    DiapatchCommanderInfo dispatchedCommanders = new()
                    {
                        cid = item.Value.cid,
                        engageCnt = engageCount,
                        runtime = dispatchTime,
                        getGold = gold
                    };

                    dispatchedcommanders.Add(item.Key, dispatchedCommanders);
                }
            }
            else
            {
                dispatchedcommanders = null;
            }

            ResponsePacket responsePacket = new()
            {
                Id = BasePacket.Id,
                Result = dispatchedcommanders,
            };

            return responsePacket;
        }

        public int GetDispatchGold(string level, string cls, string rank) => GetDispatchGold(int.Parse(level), int.Parse(cls), int.Parse(rank));

        public int GetDispatchGold(int level, int cls, int rank)
        {
            return (int)((level + cls) * rank / 11f * 60f);
        }

        public float GetdispatchFloatGold(string level, string cls, string rank) => GetDispatchGold(int.Parse(level), int.Parse(cls), int.Parse(rank));

        public float GetdispatchFloatGold(int level, int cls, int rank)
        {
            return (level + cls) * rank / 11f * 60f;
        }
    }

    public class GetDispatchCommanderListFromLoginRequest
    {
    }
}