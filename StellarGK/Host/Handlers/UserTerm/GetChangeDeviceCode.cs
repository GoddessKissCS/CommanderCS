using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.GetChangeDeviceCode)]
    public class GetChangeDeviceCode : BaseCommandHandler<GetChangeDeviceCodeRequest>
    {
        public override string Handle(GetChangeDeviceCodeRequest @params)
        {
            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = RequestForChangeDeviceCode(BasePacket.Session)
            };


            return JsonConvert.SerializeObject(response);
        }

        private static string RequestForChangeDeviceCode(string sess)
        {
            var account = DatabaseManager.Account.FindBySession(sess);

            var devicechange = DatabaseManager.DeviceCode.FindByUid(account.Id);

            // TODO - ADDING CHECK ON IF DEVICECODE IS OLDER THAN 7 DAYS I SUPPOSE

            try
            {
                if (devicechange == null)
                {
                    var device = DatabaseManager.DeviceCode.Create(account.Id);

                    return device.code;
                }
            }
            catch (Exception ex)
            {
                _ = ex;
                return "Contact Admin";
            }
            return devicechange.code;

        }

    }
    public class GetChangeDeviceCodeRequest
    {

    }
}
