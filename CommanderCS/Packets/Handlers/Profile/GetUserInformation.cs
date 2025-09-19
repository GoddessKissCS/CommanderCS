using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Profile
{
    [Packet(Id = Method.GetUserInformation)]
    public class GetUserInformation : BaseMethodHandler<GetUserInformationRequest>
    {
        public override object Handle(GetUserInformationRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

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