using CommanderCS.Database;
using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.SetPushOnOff)]
    public class SetPushOnOff : BaseMethodHandler<SetPushOnOffRequest>
    {
        public override object Handle(SetPushOnOffRequest @params)
        {
            var session = GetSession();

            var result = DatabaseManager.GameProfile.UpdateNotifaction(session, @params.onoff);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = result.ToString(),
            };

            return response;
        }
    }

    public class SetPushOnOffRequest
    {
        [JsonProperty("onoff")]
        public int onoff { get; set; }
    }
}