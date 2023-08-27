using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Packet(Id = Method.GetEventNotice)]
    public class GetEventNotice : BaseMethodHandler<GetEventNoticeRequest>
    {

        public override object Handle(GetEventNoticeRequest @params)
        {

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

            ResponsePacket response = new()
            {
                Result = EventNotice1,
                Id = BasePacket.Id
            };

            return response;
        }

    }

    public class GetEventNoticeRequest
    {

    }

}