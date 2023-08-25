using StellarGK.Host.Handlers.Battle;
using StellarGK.Host;
using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Packets.Handlers.Mail
{
	[Packet(MethodId.ReadMail)]
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