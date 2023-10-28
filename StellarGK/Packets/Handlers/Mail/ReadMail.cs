using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Host;

namespace StellarGK.Packets.Handlers.Mail
{
    [Packet(Id = Method.ReadMail)]
    public class ReadMail : BaseMethodHandler<ReadMailRequest>
    {
        public override object Handle(ReadMailRequest @params)
        {
#warning TODO: ADDING THE REWARD TO THE ACCOUNT

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
        [JsonProperty("idx")]
        public int Idx { get; set; }
    }
}