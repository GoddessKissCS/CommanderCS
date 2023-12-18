using CommanderCS.Database.Schemes;
using CommanderCSLibrary.Shared;
using MongoDB.Driver;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseDeviceCode : DatabaseTable<DeviceChangeCodeScheme>
    {
        public DatabaseDeviceCode() : base("DeviceChangeCode")
        {
        }

        public DeviceChangeCodeScheme Create(int id)
        {
            var Code = Utility.ChangeDeviceCode();
            var CreateTime = TimeManager.CurrentEpoch;

            DeviceChangeCodeScheme deviceCode = new()
            {
                MemberId = id,
                Code = Code,
                CreateTime = CreateTime,
            };

            DatabaseCollection.InsertOne(deviceCode);

            return deviceCode;
        }

        public DeviceChangeCodeScheme? FindByUid(int uid)
        {
            return DatabaseCollection.AsQueryable().Where(deviceScheme => deviceScheme.MemberId == uid).FirstOrDefault();
        }

        public DeviceChangeCodeScheme? FindByDeviceCode(string code)
        {
            return DatabaseCollection.AsQueryable().Where(deviceScheme => deviceScheme.Code == code).FirstOrDefault();
        }

        public string RequestForChangeDeviceCode(AccountScheme? account)
        {
            var devicechange = DatabaseManager.DeviceCode.FindByUid(account.MemberId);

            var timeDifference = TimeManager.GetTimeDifferenceInDays(devicechange.CreateTime);

            if (timeDifference > 7)
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
}