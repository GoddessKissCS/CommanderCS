using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.GuildInfo)]
    public class GuildInfo : BaseMethodHandler<GuildInfoRequest>
    {
        public override object Handle(GuildInfoRequest @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = DatabaseGetUserInformationResponse(User),
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