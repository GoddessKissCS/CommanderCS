using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.UserTerm
{
    [Packet(Id = Method.GetChangeDeviceCode)]
    public class GetChangeDeviceCode : BaseMethodHandler<GetChangeDeviceCodeRequest>
    {
        public override object Handle(GetChangeDeviceCodeRequest @params)
        {
            AccountScheme Account = GetUserAccount();

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