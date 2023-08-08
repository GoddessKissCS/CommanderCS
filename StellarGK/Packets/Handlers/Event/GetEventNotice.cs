using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetEventNotice)]
    public class GetEventNotice : BaseCommandHandler<GetEventNoticeRequest>
    {

        public override object Handle(GetEventNoticeRequest @params)
        {
            ResponsePacket response = new();

            List<NoticeData> EventNotice1 = new()
            {
                /*
                new NoticeData()
                {
                    idx = 0,
                    img = "1",
                    notice = "TEST",
                    link = "http://",
                    startDate = 0,
                    endDate = 0,
                    eventEndDate = 0,
                    eventStartDate = 0,
                    notiFixed = 0,
                }
                */
            };

            response.result = EventNotice1;
            response.id = BasePacket.Id;

            return response;
        }

    }

    public class GetEventNoticeRequest
    {

    }

}