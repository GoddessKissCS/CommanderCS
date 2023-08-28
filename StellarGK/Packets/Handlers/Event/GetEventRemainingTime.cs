using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Event
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
            [JsonPropertyName("buff")]
            public Dictionary<string, int> buff { get; set; }
        }
    }

    public class GetEventRemainingTimeRequest
    {

    }
}