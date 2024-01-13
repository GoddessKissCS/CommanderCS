using CommanderCS.MongoDB;
using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.ReadMail)]
    public class ReadMail : BaseMethodHandler<ReadMailRequest>
    {
        public override object Handle(ReadMailRequest @params)
        {
            var session = GetSession();

#warning TODO: ADDING THE REWARD TO THE ACCOUNT

            bool result = DatabaseManager.GameProfile.ReadMail(session, @params.Idx);

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