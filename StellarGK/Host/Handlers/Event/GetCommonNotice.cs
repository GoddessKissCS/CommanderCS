using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetCommonNotice)]
    public class GetCommonNotice : BaseCommandHandler<GetCommonNoticeRequest>
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

            response.result = CommonNotice1;
            response.id = BasePacket.Id;

            return response;
        }
    }
    public class GetCommonNoticeRequest
    {

    }
}