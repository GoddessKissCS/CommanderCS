using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Event
{
    [Packet(Id = MethodId.GetEventRemaingTime)]
    public class GetEventRemainingTime : BaseMethodHandler<GetEventRemainingTimeRequest>
    {
        public override object Handle(GetEventRemainingTimeRequest @params)
        {
            var test = new Dictionary<string, int>()
                    {
                        {"test", 1}
                    };

            GetEventRemainingTimeM getEventRemainingTimeM = new()
            {
                buff = test,
            };


            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = getEventRemainingTimeM,
            };

            return response;
        }


        public class GetEventRemainingTimeM
        {
            [JsonPropertyName("buff")]
            public Dictionary<string, int> buff { get; set; }
        }
    }

    public class GetEventRemainingTimeRequest
    {

    }
}