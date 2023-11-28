using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.SetPushOnOff)]
    public class SetPushOnOff : BaseMethodHandler<SetPushOnOffRequest>
    {
        public override object Handle(SetPushOnOffRequest @params)
        {
            var result = DatabaseManager.GameProfile.UpdateNotifaction(GetSession(), @params.onoff);

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