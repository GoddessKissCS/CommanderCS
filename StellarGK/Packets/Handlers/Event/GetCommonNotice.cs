using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Packet(MethodId.GetCommonNotice)]
    public class GetCommonNotice : BaseMethodHandler<GetCommonNoticeRequest>
    {
        public override object Handle(GetCommonNoticeRequest @params)
        {
            ResponsePacket response = new();

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

            response.Result = CommonNotice1;
            response.Id = BasePacket.Id;

            return response;
        }
    }
    public class GetCommonNoticeRequest
    {

    }
}