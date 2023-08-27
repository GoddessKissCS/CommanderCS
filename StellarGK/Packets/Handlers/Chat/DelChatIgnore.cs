using StellarGK.Database;
using StellarGK.Host;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Chat
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

        [JsonPropertyName("ch")]
        public int ch { get; set; }
        [JsonPropertyName("uno")]
        public string uno { get; set; }
    }

}