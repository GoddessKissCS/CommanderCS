using StellarGK.Database;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.GetChangeDeviceCode)]
    public class GetChangeDeviceCode : BaseCommandHandler<GetChangeDeviceCodeRequest>
    {
        public override object Handle(GetChangeDeviceCodeRequest @params)
        {
            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = RequestForChangeDeviceCode(GetSession())
            };


            return response;
        }

        private static string RequestForChangeDeviceCode(string sess)
        {
            var account = DatabaseManager.Account.FindBySession(sess);

            var devicechange = DatabaseManager.DeviceCode.FindByUid(account.memberId);

            // TODO - ADDING CHECK ON IF DEVICECODE IS OLDER THAN 7 DAYS I SUPPOSE
            // TODO ADDS SOME OTHER CHECKS ASWELL

            try
            {
                if (devicechange == null)
                {
                    var device = DatabaseManager.DeviceCode.Create(account.memberId);

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
