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
            MailInfo mailInfo = new() { };

            var MailDataNotReceived = User.MailDataList.Where(x => x.__receive == "0").ToList();

            mailInfo.mailList = MailDataNotReceived;

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