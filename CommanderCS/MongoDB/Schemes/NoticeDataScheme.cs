using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class NoticeDataScheme
    {
        public ObjectId Id { get; set; }
        public int idx { get; set; }
        public string img { get; set; }
        public string notice { get; set; }
        public string link { get; set; }
        public double startDate { get; set; }
        public double endDate { get; set; }
        public double eventStartDate { get; set; }
        public double eventEndDate { get; set; }
        public int notiFixed { get; set; }
    }
}
