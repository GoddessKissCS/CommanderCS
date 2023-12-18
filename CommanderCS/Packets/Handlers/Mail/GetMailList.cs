using CommanderCS.Host;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.GetMailList)]
    public class GetMailList : BaseMethodHandler<GetMailListRequest>
    {
        public override object Handle(GetMailListRequest @params)
        {
			var user = GetUserGameProfile();

            MailInfo mailInfo = new()
            {
                mailList = user.MailDataList
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