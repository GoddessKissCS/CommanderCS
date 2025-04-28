using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Event
{
    [Packet(Id = Method.GetEventNotice)]
    public class GetEventNotice : BaseMethodHandler<GetEventNoticeRequest>
    {
        public override object Handle(GetEventNoticeRequest @params)
        {
            List<NoticeData> EventNotice = DatabaseManager.EventNotice.GetAllEventNotice();

            ResponsePacket response = new()
            {
                Result = EventNotice,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetEventNoticeRequest
    {
    }
}