using StellarGK.Database;
using StellarGK.Host;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Mail
{
    [Packet(Id = MethodId.ReadMail)]
    public class ReadMail : BaseMethodHandler<ReadMailRequest>
    {
        public override object Handle(ReadMailRequest @params)
        {
#warning TODO: ADDING THE REWARD

            bool result = DatabaseManager.GameProfile.ReadMail(GetSession(), @params.Idx);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = result.ToString(),
            };


            return response;
        }
    }
    public class ReadMailRequest
    {
        [JsonPropertyName("idx")]
        public int Idx { get; set; }
    }
}