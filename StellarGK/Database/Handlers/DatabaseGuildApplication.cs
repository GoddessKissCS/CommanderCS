using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGKLibrary.Protocols;
using StellarGKLibrary.Utils;

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
                JoinMemberData = new()
                {
                    lastTime = 0,
                    level = user.UserResources.level,
                    memberGrade = 0,
                    name = user.UserResources.nickname,
                    paymentBonusPoint = 0,
                    thumnail = user.UserResources.thumbnailId,
                    todayPoint = 0,
                    totalPoint = 0,
                    uno = user.Uno,
                    world = user.Server,
                },
                ApplyTime = Utility.CurrentTimeInMilliseconds(),
                
            };

            Collection.InsertOne(guildApplication);
            return ErrorCode.Success;
        }

        public GuildApplicationScheme? FindApplicationByUno(int Uno, int guildId)
        {
            return Collection.AsQueryable().Where(d => d.Uno == Uno).Where(d => d.GuildId == guildId).FirstOrDefault();
        }

        public string RetrieveGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { return string.Empty; }

            var tryGuild = Collection.AsQueryable()
                            .Where(d => d.Uno == user.Uno)
                            .Where(d => d.GuildId == guildIdx)
                            .FirstOrDefault();

            if (tryGuild != null) { return "req"; }

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

            var filter = Builders<GuildApplicationScheme>.Filter.And(Builders<GuildApplicationScheme>.Filter.Eq("Uno", user.Uno),
                         Builders<GuildApplicationScheme>.Filter.Eq("GuildId", guildIdx));

            var result = Collection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }

        public bool DeleteGuildApplication(int uno, int guildIdx)
        {
            var filter = Builders<GuildApplicationScheme>.Filter.And(Builders<GuildApplicationScheme>.Filter.Eq("Uno", uno),
             Builders<GuildApplicationScheme>.Filter.Eq("GuildId", guildIdx));

            var result = Collection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }

        public List<GuildMember.MemberData> GetGuildApplications(int? guildId)
        {
            var guilds = new List<GuildMember.MemberData>();

            var filter = Builders<GuildApplicationScheme>.Filter.Eq("GuildId", guildId);

            List<GuildApplicationScheme> matchingEntries = Collection.Find(filter).ToList();

            foreach(var entry in matchingEntries)
            {
                guilds.Add(entry.JoinMemberData);  
            }

            return guilds;
        }

        public ErrorCode ApproveGuildJoinRequest(int uno)
        {
            var guildId = RetrieveGuildApplicationFromId(uno);

            var guild = DatabaseManager.Guild.FindByUid(guildId);

            if (guild.Count == guild.MaxCount)
            {
                return ErrorCode.FederationIsFull;
            }

            var application = FindApplicationByUno(uno, guildId);
            
            var user = DatabaseManager.GameProfile.FindByUno(uno);

            if(CheckIfRequestMemberDataChanged(application, user)) 
            {
                return ErrorCode.RequestDataHasBeenChanged;
            }

#warning TODO  
            // blablabla if federation settings change blabla
            // add thing here

            DeleteGuildApplication(uno, guildId);
            DatabaseManager.Guild.AddGuildMember(uno, guildId, application.JoinMemberData);

            return ErrorCode.Success;

        }

        private bool CheckIfRequestMemberDataChanged(GuildApplicationScheme guildApplication, GameProfileScheme user)
        {
            return guildApplication.JoinMemberData.thumnail != user.UserResources.thumbnailId || guildApplication.JoinMemberData.level != user.UserResources.level || guildApplication.JoinMemberData.name != user.UserResources.nickname || user.GuildId != null;
        }

    }
}