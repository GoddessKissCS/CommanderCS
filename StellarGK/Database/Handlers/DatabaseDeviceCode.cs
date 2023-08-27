using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Tools;

namespace StellarGK.Database.Handlers
{
    public class DatabaseDeviceCode : DatabaseTable<DeviceChangeCodeScheme>
    {
        public DatabaseDeviceCode() : base("DeviceChangeCode") { }

        public DeviceChangeCodeScheme Create(int id)
        {
            DeviceChangeCodeScheme deviceCode = new()
            {
                MemberId = id,
                Code = Constants.ChangeDeviceCode,
                CreateTime = Constants.CurrentTimeStamp,
            };

            Collection.InsertOne(deviceCode);

            return deviceCode;

        }

        public DeviceChangeCodeScheme? FindByUid(int uid)
        {
            return Collection.AsQueryable().Where(deviceScheme => deviceScheme.MemberId == uid).FirstOrDefault();
        }

        public DeviceChangeCodeScheme? FindByDeviceCode(string code)
        {
            return Collection.AsQueryable().Where(deviceScheme => deviceScheme.Code == code).FirstOrDefault();
        }

    }
}
