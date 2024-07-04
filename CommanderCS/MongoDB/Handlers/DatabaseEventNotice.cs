using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing notice data.
    /// </summary>
    public class DatabaseEventNotice : DatabaseTable<NoticeDataScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseEventNotice"/> class with the specified table name.
        /// </summary>
        public DatabaseEventNotice() : base("EventNotice")
        {
        }

        public NoticeDataScheme Insert(double startdate, double eventstartdate, double enddate, double eventenddate, int idx, string img, string link, string notice, int notifixed)
        {
            NoticeDataScheme dataInfo = new()
            {
                startDate = startdate,
                eventStartDate = eventstartdate,
                endDate = enddate,
                eventEndDate = eventenddate,
                idx = idx,
                img = img,
                link = link,
                notice = notice,
                notiFixed = notifixed
            };

            DatabaseCollection.InsertOne(dataInfo);

            return dataInfo;
        }

        public List<NoticeData> GetAllEventNotice()
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
                    startDate = notice.startDate,
                    eventStartDate = notice.eventStartDate,
                    endDate = notice.endDate,
                    eventEndDate = notice.eventEndDate,
                    idx = notice.idx,
                    img = notice.img,
                    link = notice.link,
                    notice = notice.notice,
                    notiFixed = notice.notiFixed,
                };

                notices.Add(noticeData);
            }

            return notices;

        }


        public bool DeleteEventNotice(int idx)
        {
            var filter = Builders<NoticeDataScheme>.Filter.Eq("idx", idx);

            var result = DatabaseCollection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }
    }
}