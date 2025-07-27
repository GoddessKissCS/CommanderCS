using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.UserTerm
{
    [Packet(Id = Method.GetChangeDeviceCode)]
    public class GetChangeDeviceCode : BaseMethodHandler<GetChangeDeviceCodeRequest>
    {
        public override object Handle(GetChangeDeviceCodeRequest @params)
        {
            Account = DatabaseManager.Account.FindBySession(BasePacket.SessionId);

            var deviceCode = DatabaseManager.DeviceCode.RequestForChangeDeviceCode(Account);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = deviceCode,
            };

            return response;
        }
    }

    public class GetChangeDeviceCodeRequest
    {
    }
}