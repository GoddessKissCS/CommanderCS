using StellarGK.Database;
using StellarGK.Host;
using StellarGK.Logic.Protocols;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Chat
{
    [Packet(Id = MethodId.AddChatIgnore)]
    public class AddChatIgnore : BaseMethodHandler<AddChatIgnoreRequest>
    {
        public override object Handle(AddChatIgnoreRequest @params)
        {

            BlockUser blockUser = new()
            {
                channel = @params.ch,
                nickName = @params.nick,
                thumbnail = @params.thumb,
                uno = @params.uno,
            };

            bool YesOrNo = DatabaseManager.GameProfile.AddBlockedUser(blockUser, GetSession());

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

        [JsonPropertyName("ch")]
        public int ch { get; set; }

        [JsonPropertyName("uno")]
        public string uno { get; set; }

        [JsonPropertyName("nick")]
        public string nick { get; set; }

        [JsonPropertyName("thumb")]
        public string thumb { get; set; }
    }

}