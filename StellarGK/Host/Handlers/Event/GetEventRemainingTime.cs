namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetEventRemaingTime)]
    public class GetEventRemainingTime : BaseCommandHandler<GetEventRemainingTimeRequest>
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
                id = BasePacket.Id,
                result = getEventRemainingTimeM,
            };

            return response;
        }


        public class GetEventRemainingTimeM
        {
            public Dictionary<string, int> buff { get; set; }
        }
    }

    public class GetEventRemainingTimeRequest
    {

    }
}