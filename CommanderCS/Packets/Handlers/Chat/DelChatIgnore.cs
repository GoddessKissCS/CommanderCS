using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Chat
{
    [Packet(Id = Method.DelChatIgnore)]
    public class DelChatIgnore : BaseMethodHandler<DelChatIgnoreRequest>
    {
        public override object Handle(DelChatIgnoreRequest @params)
        {
            bool isRemoved = DatabaseManager.GameProfile.DelBlockedUser(Session, @params.channel, @params.uno);

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
        public int channel { get; set; }

        [JsonProperty("uno")]
        public string uno { get; set; }
    }
}