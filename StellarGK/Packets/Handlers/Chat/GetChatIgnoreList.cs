namespace StellarGK.Host.Handlers.Chat
{
    [Packet(Id = Method.GetChatIgnoreList)]
    public class GetChatIgnoreList : BaseMethodHandler<GetChatIgnoreListRequest>
    {
        public override object Handle(GetChatIgnoreListRequest @params)
        {
            var user = GetUserGameProfile();


            ResponsePacket response = new()
            {
                Result = user.BlockedUsers,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetChatIgnoreListRequest
    {
    }
}