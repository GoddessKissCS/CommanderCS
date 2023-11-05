using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGKLibrary.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGuildApplication : DatabaseTable<GuildApplicationScheme>
    {
        public DatabaseGuildApplication() : base("GuildApplications")
        {
        }
        public ErrorCode CreateGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);


            if(CheckIfAnyApplicationExists(session) == "reg")
            {
                return ErrorCode.CannotSentMoreThanOneFederationJoinRequest;
            }

            GuildApplicationScheme guildApplication = new()
            {
                GuildId = guildIdx,
                Uno = user.Uno,
            };

            Collection.InsertOne(guildApplication);
            return ErrorCode.Success;
        }
        public string RetrieveGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { return string.Empty; }

            var tryGuild = Collection.AsQueryable()
                            .Where(d => d.Uno == user.Uno)
                            .Where(d => d.GuildId == guildIdx)
                            .FirstOrDefault();

            if (tryGuild != null) { return "reg"; }

            return string.Empty;
        }

        public int RetrieveGuildApplicationFromId(int uno)
        {
            var tryGuild = Collection.AsQueryable()
                            .Where(d => d.Uno == uno)
                            .FirstOrDefault();


            return tryGuild.GuildId;
        }
        public string CheckIfAnyApplicationExists(string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { return string.Empty; }

            var tryGuild = Collection.AsQueryable()
                            .Where(d => d.Uno == user.Uno)
                            .FirstOrDefault();

            if (tryGuild != null) { return "reg"; }

            return string.Empty;
        }
        public bool DeleteGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { }

            var filter = Builders<GuildApplicationScheme>.Filter.And(Builders<GuildApplicationScheme>.Filter.Eq("uno", user.Uno),
                         Builders<GuildApplicationScheme>.Filter.Eq("guildId", guildIdx));

            var result = Collection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }
        public List<GuildMember.MemberData> GetGuildApplications(int? guildId)
        {
            var guildlist = new List<GuildMember.MemberData>();

            var filter = Builders<GuildApplicationScheme>.Filter.Eq("GuildId", guildId);

            // Retrieve entries that match the filter
            List<GuildApplicationScheme> matchingEntries = Collection.Find(filter).ToList();

            foreach(var entry in matchingEntries)
            {
                var Applicant = DatabaseManager.GameProfile.FindByUno(entry.Uno);
                var guildappli = new GuildMember.MemberData()
                {
                    thumnail = Applicant.UserResources.thumbnailId,
                    level = Applicant.UserResources.level,
                    name = Applicant.UserResources.nickname,
                    todayPoint = 0,
                    lastTime = 0,
                    paymentBonusPoint = 0,
                    memberGrade = 0,
                    totalPoint = 0,
                    uno = entry.Uno,
                    world = Applicant.Server,
                };

                guildlist.Add(guildappli);  

            }

            return guildlist;
        }

        public ErrorCode ApproveGuildJoin(string session, int uno)
        {
            var guildJoinRequester = DatabaseManager.GameProfile.FindByUno(uno);

            var guildId = RetrieveGuildApplicationFromId(uno);

            return ErrorCode.Success;

        }

    }
}