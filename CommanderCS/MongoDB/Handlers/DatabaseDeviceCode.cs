using CommanderCS.MongoDB.Schemes;
using CommanderCS.Library.Shared;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for device change codes.
    /// </summary>
    public class DatabaseDeviceCode : DatabaseTable<DeviceChangeCodeScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseDeviceCode"/> class.
        /// </summary>
        public DatabaseDeviceCode() : base("DeviceChangeCode")
        {
        }

        /// <summary>
        /// Inserts a new device change code for the specified member ID.
        /// </summary>
        /// <param name="id">The member ID associated with the device change code.</param>
        /// <returns>The inserted device change code.</returns>
        public DeviceChangeCodeScheme Insert(int id)
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

        /// <summary>
        /// Finds a device change code by the specified member ID.
        /// </summary>
        /// <param name="uid">The member ID associated with the device change code.</param>
        /// <returns>The device change code associated with the member ID, or null if not found.</returns>
        public DeviceChangeCodeScheme? FindByUid(int uid)
        {
            return DatabaseCollection.AsQueryable().Where(deviceScheme => deviceScheme.MemberId == uid).FirstOrDefault();
        }

        /// <summary>
        /// Finds a device change code by the specified code.
        /// </summary>
        /// <param name="code">The code associated with the device change code.</param>
        /// <returns>The device change code with the specified code, or null if not found.</returns>
        public DeviceChangeCodeScheme? FindByDeviceCode(string code)
        {
            return DatabaseCollection.AsQueryable().Where(deviceScheme => deviceScheme.Code == code).FirstOrDefault();
        }

        /// <summary>
        /// Requests a device change code for the specified account.
        /// </summary>
        /// <param name="account">The account for which the device change code is requested.</param>
        /// <returns>
        /// The device change code if successfully requested and not expired,
        /// "Code Expired" if the code has expired,
        /// "Contact Admin" if there was an error during the request.
        /// </returns>
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
                if (devicechange is null)
                {
                    var device = DatabaseManager.DeviceCode.Insert(account.MemberId);

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