using MongoDB.Bson;

namespace StellarGK.Database.Schemes
{
    public class DeviceChangeCodeScheme
    {
        public ObjectId Id { get; set; }
        public int memberId { get; set; }
        public string code { get; set; }
        public int createTime { get; set; }
    }
}
