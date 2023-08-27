using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Packet(Id = Method.GetCommonNotice)]
    public class GetCommonNotice : BaseMethodHandler<GetCommonNoticeRequest>
    {
        public override object Handle(GetCommonNoticeRequest @params)
        {

            List<NoticeData> CommonNotice1 = new List<NoticeData>
            { /*
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
                Result = CommonNotice1,
                Id = BasePacket.Id
            };

            return response;
        }
    }
    public class GetCommonNoticeRequest
    {

    }
}