using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Event
{
    [Packet(Id = Method.GetCommonNotice)]
    public class GetCommonNotice : BaseMethodHandler<GetCommonNoticeRequest>
    {
        public override object Handle(GetCommonNoticeRequest @params)
        {
            List<NoticeData> CommonNotice = DatabaseManager.CommonNotice.GetAllCommonNotice();

            ResponsePacket response = new()
            {
                Result = CommonNotice,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetCommonNoticeRequest
    {
    }
}