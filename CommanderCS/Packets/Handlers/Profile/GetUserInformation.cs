using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Profile
{
    [Packet(Id = Method.GetUserInformation)]
    public class GetUserInformation : BaseMethodHandler<GetUserInformationRequest>
    {
        public override object Handle(GetUserInformationRequest @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

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