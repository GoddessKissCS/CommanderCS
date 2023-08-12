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

/*	// Token: 0x060060CA RID: 24778 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1230", true, true)]
	public void GetChangeDeviceCode()
	{
	}

	// Token: 0x060060CB RID: 24779 RVA: 0x001B0C98 File Offset: 0x001AEE98
	private IEnumerator GetChangeDeviceCodeResult(JsonRpcClient.Request request, string result)
	{
		UISimplePopup.CreateOK("ChangeDevicePopup").Set(true, "19517", result, string.Empty, "1001", string.Empty, string.Empty);
		yield break;
	}*/