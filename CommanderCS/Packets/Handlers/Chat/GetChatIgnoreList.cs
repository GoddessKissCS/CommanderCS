using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Chat
{
    [Packet(Id = Method.GetChatIgnoreList)]
    public class GetChatIgnoreList : BaseMethodHandler<GetChatIgnoreListRequest>
    {
        public override object Handle(GetChatIgnoreListRequest @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

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