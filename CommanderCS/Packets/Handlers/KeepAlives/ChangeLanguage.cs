using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.ChangeLanguage)]
    public class ChangeLanguage : BaseMethodHandler<ChangeLanguageRequest>
    {
        public override object Handle(ChangeLanguageRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = @params.lang,
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