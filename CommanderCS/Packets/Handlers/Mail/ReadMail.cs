using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.ReadMail)]
    public class ReadMail : BaseMethodHandler<ReadMailRequest>
    {
        public override object Handle(ReadMailRequest @params)
        {
            bool result = DatabaseManager.GameProfile.ReadMail(SessionId, @params.Idx);

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