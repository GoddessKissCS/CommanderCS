using StellarGK.Host;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.KeepAlives
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
		[JsonPropertyName("lang")]
		public string lang { get; set; }
	}
}