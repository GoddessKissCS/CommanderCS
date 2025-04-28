using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Chat
{
    [Packet(Id = Method.AddChatIgnore)]
    public class AddChatIgnore : BaseMethodHandler<AddChatIgnoreRequest>
    {
        public override object Handle(AddChatIgnoreRequest @params)
        {
            BlockUser blockUser = new()
            {
                channel = @params.channel,
                nickName = @params.nickname,
                thumbnail = @params.thumbnail,
                uno = @params.uno,
            };

            DatabaseManager.GameProfile.AddBlockedUser(SessionId, blockUser);

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
        public int channel { get; set; }

        [JsonProperty("uno")]
        public string uno { get; set; }

        [JsonProperty("nick")]
        public string nickname { get; set; }

        [JsonProperty("thumb")]
        public string thumbnail { get; set; }
    }
}