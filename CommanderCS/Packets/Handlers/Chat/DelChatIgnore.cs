using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.Chat
{
    [Packet(Id = Method.DelChatIgnore)]
    public class DelChatIgnore : BaseMethodHandler<DelChatIgnoreRequest>
    {
        public override object Handle(DelChatIgnoreRequest @params)
        {
            bool isRemoved = DatabaseManager.GameProfile.DelBlockedUser(GetSession(), @params.ch, @params.uno);

            ResponsePacket response = new()
            {
                Result = isRemoved,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class DelChatIgnoreRequest
    {
        [JsonProperty("ch")]
        public int ch { get; set; }

        [JsonProperty("uno")]
        public string uno { get; set; }
    }
}