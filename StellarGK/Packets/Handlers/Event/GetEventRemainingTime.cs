using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Event
{
    [Packet(Id = Method.GetEventRemaingTime)]
    public class GetEventRemainingTime : BaseMethodHandler<GetEventRemainingTimeRequest>
    {
        public override object Handle(GetEventRemainingTimeRequest @params)
        {
            GetEventRemainingTimeResponse remainingEventTime = new()
            {
                buff = new() { }
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = remainingEventTime,
            };

            return response;
        }

        public class GetEventRemainingTimeResponse
        {
            [JsonProperty("buff")]
            public Dictionary<string, int> buff { get; set; }
        }
    }

    public class GetEventRemainingTimeRequest
    {
    }
}