namespace StellarGK.Host.Handlers.Chat
{
    [Command(Id = CommandId.GetChatIgnoreList)]
    public class GetChatIgnoreList : BaseCommandHandler<GetChatIgnoreListRequest>
    {
        public override object Handle(GetChatIgnoreListRequest @params)
        {
            ResponsePacket response = new()
            {
                result = GetGameProfile().blockedUsers,
                id = BasePacket.Id
            };

            return response;
        }


    }

    public class GetChatIgnoreListRequest
    {

    }
}