namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetWebEvent)]
    public class GetWebEvent : BaseCommandHandler<GetWebEventRequest>
    {
        public override object Handle(GetWebEventRequest @params)
        {
            GetWebEventPacket gwe = new()
            {
                wev = new List<string>() { "NONE" }
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = gwe,
            };

            return response;
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