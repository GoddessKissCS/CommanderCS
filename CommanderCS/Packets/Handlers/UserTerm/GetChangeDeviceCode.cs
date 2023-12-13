using CommanderCS.Database;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetChangeDeviceCode)]
    public class GetChangeDeviceCode : BaseMethodHandler<GetChangeDeviceCodeRequest>
    {
        public override object Handle(GetChangeDeviceCodeRequest @params)
        {
            var userAccount = GetUserAccount();

            var deviceCode = DatabaseManager.DeviceCode.RequestForChangeDeviceCode(userAccount);

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