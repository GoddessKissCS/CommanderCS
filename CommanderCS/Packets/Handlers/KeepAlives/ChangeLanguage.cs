using CommanderCS.Library.Enums;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.ChangeLanguage)]
    public class ChangeLanguage : BaseMethodHandler<ChangeLanguageRequest>
    {
        public override object Handle(ChangeLanguageRequest request)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = request.lang,
            };

            return response;
        }
    }

    public class ChangeLanguageRequest
    {
        [JsonProperty("lang")]
        public string lang { get; set; }
    }
}