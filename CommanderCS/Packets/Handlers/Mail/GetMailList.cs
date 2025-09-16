using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.GetMailList)]
    public class GetMailList : BaseMethodHandler<GetMailListRequest>
    {
        public override object Handle(GetMailListRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

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