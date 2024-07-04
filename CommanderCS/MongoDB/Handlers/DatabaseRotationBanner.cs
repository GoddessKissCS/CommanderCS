using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing rotation banner data.
    /// </summary>
    public class DatabaseRotationBanner : DatabaseTable<RotationBannerScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRotationBanner"/> class with the specified table name.
        /// </summary>
        public DatabaseRotationBanner() : base("RotationBanner")
        {
        }


        public RotationBannerScheme Insert(string startdate, string enddate, int eventId, int id, string imgUrl, string link, BannerListType bannerType)
        {
            RotationBannerScheme dataInfo = new()
            {
                startDate = startdate,
                endDate = enddate,
                eventIdx = eventId,
                ImgUrl = imgUrl,
                linkIdx = id,
                linkType = bannerType
            };

            DatabaseCollection.InsertOne(dataInfo);

            return dataInfo;
        }


        public List<RotationBanner.BannerList> GetAllCurrentBannersList()
        {
            var noticedata = DatabaseCollection.AsQueryable().ToList();

            if (noticedata == null)
            {
                return null;
            }

            List<RotationBanner.BannerList> banners = [];

            foreach (var notice in noticedata)
            {
                RotationBanner.BannerList noticeData = new()
                {
                    startDate = notice.startDate,
                    endDate = notice.endDate,
                    eventIdx = notice.eventIdx,
                    ImgUrl = notice.ImgUrl,
                    linkIdx = notice.linkIdx,
                    linkType = notice.linkType
                };

                if (notice.linkIdx == 0) {

                    var time = TimeManager.TomorrowEpochInMilliseconds;
                    notice.endDate = time.ToString();
                }

                if (notice.linkIdx == 1)
                {

                    var time = TimeManager.TomorrowEpochInMilliseconds;
                    notice.endDate = time.ToString();
                }


                banners.Add(noticeData);
            }

            return banners;
        }

    }
}