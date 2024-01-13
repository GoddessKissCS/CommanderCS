using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.Dispatch
{
    [Packet(Id = Method.GetDispatchCommanderListFromLogin)]
    public class GetDispatchCommanderListFromLogin : BaseMethodHandler<GetDispatchCommanderListFromLoginRequest>
    {
        public override object Handle(GetDispatchCommanderListFromLoginRequest @params)
        {
            var user = GetUserGameProfile();

            ResponsePacket responsePacket = new()
            {
                Id = BasePacket.Id,
                Result = user.DispatchedCommanders,
            };

            return responsePacket;
        }
    }

    public class GetDispatchCommanderListFromLoginRequest
    {
    }
}