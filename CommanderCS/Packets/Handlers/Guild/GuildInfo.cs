using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Host.Handlers.Guild
{
    [Packet(Id = Method.GuildInfo)]
    public class GuildInfo : BaseMethodHandler<GuildInfoRequest>
    {
        public override object Handle(GuildInfoRequest @params)
        {

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = GetDatabaseUserInformationResponse(User),
            };

            return response;
        }
    }

    public class GuildInfoRequest
    {
        [JsonProperty("type")]
        public List<string> Type { get; set; }
    }
}