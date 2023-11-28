using MongoDB.Bson;

namespace CommanderCS.Database.Schemes
{
    public class DeviceChangeCodeScheme
    {
        public ObjectId Id { get; set; }
        public int MemberId { get; set; }
        public string Code { get; set; }
        public long CreateTime { get; set; }
    }
}