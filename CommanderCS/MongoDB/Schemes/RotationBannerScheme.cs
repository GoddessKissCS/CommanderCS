using CommanderCSLibrary.Shared.Enum;
using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class RotationBannerScheme
    {
        public ObjectId Id { get; set; }
        public string ImageUrl { get; set; }
        public BannerListType BannerListType { get; set; }
        public int LinkIdx { get; set; }
        public int EventIdx { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
    }
}