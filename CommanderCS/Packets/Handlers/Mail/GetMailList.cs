using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.GetMailList)]
    public class GetMailList : BaseMethodHandler<GetMailListRequest>
    {
        public override object Handle(GetMailListRequest @params)
        {
            MailInfo mailInfo = new()
            {
                mailList = User.MailDataList
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = mailInfo,
            };

            return response;
        }
    }

    public class GetMailListRequest
    {
    }
}