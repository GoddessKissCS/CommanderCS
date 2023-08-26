using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Packet(Id = MethodId.GetEventNotice)]
    public class GetEventNotice : BaseMethodHandler<GetEventNoticeRequest>
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

            response.Result = EventNotice1;
            response.Id = BasePacket.Id;

            return response;
        }

    }

    public class GetEventNoticeRequest
    {

    }

}