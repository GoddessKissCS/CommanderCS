namespace StellarGK.Host.Handlers.Dispatch
{
    [Command(Id = CommandId.GetDispatchCommanderListFromLogin)]
    public class GetDispatchCommanderListFromLogin : BaseCommandHandler<GetDispatchCommanderListFromLoginRequest>
    {

        public override object Handle(GetDispatchCommanderListFromLoginRequest @params)
        {
            ResponsePacket responsePacket = new()
            {
                id = BasePacket.Id,
                result = GetGameProfile().dispatchedCommanders,
            };

            return responsePacket;
        }


    }
    public class GetDispatchCommanderListFromLoginRequest
    {

    }
}