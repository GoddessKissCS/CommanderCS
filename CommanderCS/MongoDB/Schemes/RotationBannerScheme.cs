using CommanderCSLibrary.Shared.Enum;
using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class RotationBannerScheme
    {
        public ObjectId Id { get; set; }
        public string ImgUrl { get; set; }
        public BannerListType linkType { get; set; }
        public int linkIdx { get; set; }
        public int eventIdx { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
