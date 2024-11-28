using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class NoticeDataScheme
    {
        public ObjectId Id { get; set; }
        public int Idx { get; set; }
        public string ImageUrl { get; set; }
        public string Notice { get; set; }
        public string Link { get; set; }
        public double StartDateTime { get; set; }
        public double EndDateTime { get; set; }
        public double EventStartDate { get; set; }
        public double EventEndDate { get; set; }
        public int NotifiactionFixed { get; set; }
    }
}
