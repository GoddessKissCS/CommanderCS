using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class DailyBonusScheme
    {
        public ObjectId Id { get; set; }
        public string uno { get; set; }
        public int day { get; set; }
        public int received { get; set; }
    }
}