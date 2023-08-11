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
                Id = id,
                code = Constants.ChangeDeviceCode,
                createTime = Constants.CurrentTimeStamp,
            };

            collection.InsertOne(deviceCode);

            return deviceCode;

        }

        public DeviceChangeCodeScheme? FindByUid(int uid)
        {
            DeviceChangeCodeScheme? user = collection.AsQueryable().Where(d => d.Id == uid).FirstOrDefault();
            return user;
        }
    }
}
