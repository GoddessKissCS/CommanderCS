using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Chat
{
    [Packet(Id = Method.GetChatIgnoreList)]
    public class GetChatIgnoreList : BaseMethodHandler<GetChatIgnoreListRequest>
    {
        public override object Handle(GetChatIgnoreListRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

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