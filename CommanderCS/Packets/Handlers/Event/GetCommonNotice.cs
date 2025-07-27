using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Event
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