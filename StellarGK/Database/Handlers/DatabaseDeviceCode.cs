using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGKLibrary.Utils;

namespace StellarGK.Database.Handlers
{
    public class DatabaseDeviceCode : DatabaseTable<DeviceChangeCodeScheme>
    {
        public DatabaseDeviceCode() : base("DeviceChangeCode") { }

        public DeviceChangeCodeScheme Create(int id)
        {

            var Code = Utility.ChangeDeviceCode();
            var CreateTime = Utility.CurrentTimeStamp();

            DeviceChangeCodeScheme deviceCode = new()
            {
                MemberId = id,
                Code = Code,
                CreateTime = CreateTime,
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
