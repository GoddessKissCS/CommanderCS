using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing notice data.
    /// </summary>
    public class DatabaseCommonNotice : DatabaseTable<NoticeDataScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseEventNotice"/> class with the specified table name.
        /// </summary>
        public DatabaseCommonNotice() : base("CommonNotice")
        {
        }

        public NoticeDataScheme Insert(double startdate, double eventstartdate, double enddate, double eventenddate, int idx, string img, string link, string notice, int notifixed)
        {
            NoticeDataScheme dataInfo = new()
            {
                StartDateTime = startdate,
                EventStartDate = eventstartdate,
                EndDateTime = enddate,
                EventEndDate = eventenddate,
                Idx = idx,
                ImageUrl = img,
                Link = link,
                Notice = notice,
                NotifiactionFixed = notifixed
            };

            DatabaseCollection.InsertOne(dataInfo);

            return dataInfo;
        }

        public List<NoticeData> GetAllCommonNotice()
        {
            var noticedata = DatabaseCollection.AsQueryable().ToList();

            if (noticedata == null)
            {
                return null;
            }

            List<NoticeData> notices = [];

            foreach (var notice in noticedata)
            {
                NoticeData noticeData = new()
                {
                    startDate = notice.StartDateTime,
                    eventStartDate = notice.EventStartDate,
                    endDate = notice.EndDateTime,
                    eventEndDate = notice.EventEndDate,
                    idx = notice.Idx,
                    img = notice.ImageUrl,
                    link = notice.Link,
                    notice = notice.Notice,
                    notiFixed = notice.NotifiactionFixed,
                };

                notices.Add(noticeData);
            }

            return notices;

        }


        public bool DeleteEventNotice(int idx)
        {
            var filter = Builders<NoticeDataScheme>.Filter.Eq("Idx", idx);

            var result = DatabaseCollection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }


    }
}