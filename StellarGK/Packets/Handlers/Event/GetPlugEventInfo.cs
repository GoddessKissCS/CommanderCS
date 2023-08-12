using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetPlugEventInfo)]
    public class GetPlugEventInfo : BaseCommandHandler<GetPlugEventInfoRequest>
    {
        public override object Handle(GetPlugEventInfoRequest @params)
        {
            ResponsePacket response = new();

            GetPlugEventInfoPacket plugEventInfo = new()
            {
                cmt = new List<int>() { },
                pst = new List<int>() { }
            };

            response.id = BasePacket.Id;
            response.result = plugEventInfo;

            return response;
        }

        public class GetPlugEventInfoPacket
        {
            [JsonPropertyName("pst")]
            public List<int> pst { get; set; }

            [JsonPropertyName("cmt")]
            public List<int> cmt { get; set; }
        }
    }

    public class GetPlugEventInfoRequest
    {

    }
}