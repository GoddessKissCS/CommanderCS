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
                StartDateTime = startdate,
                EndDateTime = enddate,
                EventIdx = eventId,
                ImageUrl = imgUrl,
                LinkIdx = id,
                BannerListType = bannerType
            };

            DatabaseCollection.InsertOne(dataInfo);

            return dataInfo;
        }

        public List<RotationBanner.BannerList> GetAllCurrentBannersList()
        {
            var noticedata = DatabaseCollection.AsQueryable().ToList();

            if (noticedata is null)
            {
                return null;
            }

            List<RotationBanner.BannerList> banners = [];

            foreach (var notice in noticedata)
            {
                RotationBanner.BannerList noticeData = new()
                {
                    startDate = notice.StartDateTime,
                    endDate = notice.EndDateTime,
                    eventIdx = notice.EventIdx,
                    ImgUrl = notice.ImageUrl,
                    linkIdx = notice.LinkIdx,
                    linkType = notice.BannerListType
                };

                if (notice.LinkIdx == 0 || notice.LinkIdx == 1)
                {
                    var time = TimeManager.TomorrowEpochInMilliseconds;
                    notice.EndDateTime = time.ToString();
                }

                banners.Add(noticeData);
            }

            return banners;
        }
    }
}