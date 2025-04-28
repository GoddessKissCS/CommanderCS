using CommanderCS.Library.Shared.Enum;

namespace CommanderCS.Host.Handlers.Chat
{
    [Packet(Id = Method.GetChatIgnoreList)]
    public class GetChatIgnoreList : BaseMethodHandler<GetChatIgnoreListRequest>
    {
        public override object Handle(GetChatIgnoreListRequest @params)
        {
            ResponsePacket response = new()
            {
                Result = User.BlockedUsers,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetChatIgnoreListRequest
    {
    }
}