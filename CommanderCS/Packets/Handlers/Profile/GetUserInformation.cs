using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Profile
{
    [Packet(Id = Method.GetUserInformation)]
    public class GetUserInformation : BaseMethodHandler<GetUserInformationRequest>
    {
        public override object Handle(GetUserInformationRequest @params)
        {
            var userInformationResponse = GetUserInformationResponse(User);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
    }

    public class GetUserInformationRequest
    {
        [JsonProperty("type")]
        public List<string> Type { get; set; }
    }
}