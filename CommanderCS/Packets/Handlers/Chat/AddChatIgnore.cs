using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCS.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Chat
{
    [Packet(Id = Method.AddChatIgnore)]
    public class AddChatIgnore : BaseMethodHandler<AddChatIgnoreRequest>
    {
        public override object Handle(AddChatIgnoreRequest @params)
        {
            var session = GetSession();

            BlockUser blockUser = new()
            {
                channel = @params.ch,
                nickName = @params.nick,
                thumbnail = @params.thumb,
                uno = @params.uno,
            };

            DatabaseManager.GameProfile.AddBlockedUser(blockUser, session);

            ResponsePacket response = new()
            {
                Result = blockUser,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class AddChatIgnoreRequest
    {
        [JsonProperty("ch")]
        public int ch { get; set; }

        [JsonProperty("uno")]
        public string uno { get; set; }

        [JsonProperty("nick")]
        public string nick { get; set; }

        [JsonProperty("thumb")]
        public string thumb { get; set; }
    }
}