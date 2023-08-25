namespace StellarGK.Host.Handlers.Chat
{
    [Packet(MethodId.GetChatIgnoreList)]
    public class GetChatIgnoreList : BaseMethodHandler<GetChatIgnoreListRequest>
    {
        public override object Handle(GetChatIgnoreListRequest @params)
        {
            ResponsePacket response = new()
            {
                Result = GetUserGameProfile().BlockedUsers,
                Id = BasePacket.Id
            };

            return response;
        }


    }

    public class GetChatIgnoreListRequest
    {

    }
}