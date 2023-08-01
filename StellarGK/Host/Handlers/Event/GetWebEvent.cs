using Newtonsoft.Json;

namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetWebEvent)]
    public class GetWebEvent : BaseCommandHandler<GetWebEventRequest>
    {
        public override string Handle(GetWebEventRequest @params)
        {
            GetWebEventPacket gwe = new()
            {
                wev = new List<string>() { "NONE" }
            };

            ResponsePacket GWEM = new()
            {
                id = BasePacket.Id,
                result = gwe,
            };

            return JsonConvert.SerializeObject(GWEM);
        }


        public class GetWebEventPacket
        {
            public List<string> wev { get; set; }
        }
    }

    public class GetWebEventRequest
    {
        
    }
}