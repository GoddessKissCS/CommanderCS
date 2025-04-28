using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;

namespace CommanderCS.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetChangeDeviceCode)]
    public class GetChangeDeviceCode : BaseMethodHandler<GetChangeDeviceCodeRequest>
    {
        public override object Handle(GetChangeDeviceCodeRequest @params)
        {
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