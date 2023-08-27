namespace StellarGK.Host.Handlers.Dispatch
{
    [Packet(Id = Method.GetDispatchCommanderListFromLogin)]
    public class GetDispatchCommanderListFromLogin : BaseMethodHandler<GetDispatchCommanderListFromLoginRequest>
    {

        public override object Handle(GetDispatchCommanderListFromLoginRequest @params)
        {
            ResponsePacket responsePacket = new()
            {
                Id = BasePacket.Id,
                Result = GetUserGameProfile().DispatchedCommanders,
            };

            return responsePacket;
        }


    }
    public class GetDispatchCommanderListFromLoginRequest
    {

    }
}