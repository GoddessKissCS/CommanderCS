using CommanderCS.Protocols;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Host.Handlers.Event
{
    [Packet(Id = Method.GetCommonNotice)]
    public class GetCommonNotice : BaseMethodHandler<GetCommonNoticeRequest>
    {
        public override object Handle(GetCommonNoticeRequest @params)
        {
            List<NoticeData> CommonNotice1 = [];

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