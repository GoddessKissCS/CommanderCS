using MongoDB.Bson;

namespace StellarGK.Database.Schemes
{
    public class DeviceChangeCodeScheme
    {
        public ObjectId Id { get; set; }
        public int MemberId { get; set; }
        public string Code { get; set; }
        public int CreateTime { get; set; }
    }
}
