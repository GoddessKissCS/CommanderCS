using StellarGK.Database;
using StellarGK.Database.Schemes;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetChangeDeviceCode)]
    public class GetChangeDeviceCode : BaseMethodHandler<GetChangeDeviceCodeRequest>
    {
        public override object Handle(GetChangeDeviceCodeRequest @params)
        {

            var userAccount = GetUserAccount();

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = RequestForChangeDeviceCode(userAccount)
            };

            return response;
        }

        private static string RequestForChangeDeviceCode(AccountScheme? account)
        {
            var devicechange = DatabaseManager.DeviceCode.FindByUid(account.MemberId);

            DateTime createTimeDate = DateTime.ParseExact(devicechange.CreateTime.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan timeDifference = DateTime.Now - createTimeDate;
            int daysDifference = (int)timeDifference.TotalDays;

            if (daysDifference > 7)
            {
                return "Code Expired";
            }

            try
            {
                if (devicechange == null)
                {
                    var device = DatabaseManager.DeviceCode.Create(account.MemberId);

                    return device.Code;
                }
            }
            catch (Exception _)
            {
                return "Contact Admin";
            }
            return devicechange.Code;

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