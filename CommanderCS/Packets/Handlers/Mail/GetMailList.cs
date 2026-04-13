using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.GetMailList)]
    public class GetMailList : BaseMethodHandler<GetMailListRequest>
    {
        public override object Handle(GetMailListRequest request)
        {
            var user = GetUserGameProfile();

            // Only send mails that haven't been received yet to the player
            var unreceivedMail = user.MailDataList?
                .Where(m => m.__receive != "1")
                .ToList();

            MailInfo mailInfo = new()
            {
                mailList = unreceivedMail,
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