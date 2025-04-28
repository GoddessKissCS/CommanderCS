using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.SetPushOnOff)]
    public class SetPushOnOff : BaseMethodHandler<SetPushOnOffRequest>
    {
        public override object Handle(SetPushOnOffRequest @params)
        {
            var result = DatabaseManager.GameProfile.UpdateNotifaction(SessionId, @params.onoff);

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