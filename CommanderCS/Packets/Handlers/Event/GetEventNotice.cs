using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.Event
{
    [Packet(Id = Method.GetEventNotice)]
    public class GetEventNotice : BaseMethodHandler<GetEventNoticeRequest>
    {
        public override object Handle(GetEventNoticeRequest @params)
        {
            List<NoticeData> EventNotice1 = [];

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