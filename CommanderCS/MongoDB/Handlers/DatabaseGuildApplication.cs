using CommanderCS.Library;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Ro;
using CommanderCS.MongoDB.Schemes;
using CommanderCS.Packets;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing guild applications.
    /// </summary>
    public class DatabaseGuildApplication : DatabaseTable<GuildApplicationScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseGuildApplication"/> class with the specified table name.
        /// </summary>
        public DatabaseGuildApplication() : base("GuildApplication")
        {
        }

        /// <summary>
        /// Creates a guild application for a user to join a guild.
        /// </summary>
        /// <param name="session">The session identifier of the user.</param>
        /// <param name="guildIdx">The unique identifier of the guild to apply for.</param>
        /// <returns>An error code indicating the result of the operation.</returns>
        public ErrorCode CreateGuildApplication(string session, int guildIdx)
        {
            if (CheckIfAnyApplicationExists(session) == "reg")
            {
                return ErrorCode.CannotSentMoreThanOneFederationJoinRequest;
            }

            var user = DatabaseManager.GameProfile.FindBySession(session);

            var time = TimeManager.CurrentEpochMilliseconds;

            GuildApplicationScheme guildApplication = new()
            {
                GuildId = guildIdx,
                Uno = user.Uno,
                JoinMemberData = new()
                {
                    lastTime = 0,
                    level = user.Resources.level,
                    memberGrade = 0,
                    name = user.Resources.nickname,
                    paymentBonusPoint = 0,
                    thumnail = user.Resources.thumbnailId,
                    todayPoint = 0,
                    totalPoint = 0,
                    uno = user.Uno,
                    world = user.Server,
                },
                ApplyTime = time,
            };

            DatabaseCollection.InsertOne(guildApplication);

            return ErrorCode.Success;
        }

        /// <summary>
        /// Finds a guild application by the unique identifier of the user and the guild.
        /// </summary>
        /// <param name="Uno">The unique identifier of the user.</param>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <returns>The guild application if found; otherwise, null.</returns>
        public GuildApplicationScheme? FindApplicationByUno(int Uno, int guildId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Uno == Uno).Where(d => d.GuildId == guildId).FirstOrDefault();
        }

        /// <summary>
        /// Checks if a guild application exists from the given user's session and guild index.
        /// </summary>
        /// <param name="session">The session of the user.</param>
        /// <param name="guildIdx">The unique identifier of the guild.</param>
        /// <returns>'req' if the user has applied to join the guild, otherwise an empty string.</returns>
        public string GuildApplicationFromGuildId(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user is null) { return string.Empty; }

            var tryGuild = DatabaseCollection.AsQueryable()
                           .Where(d => d.Uno == user.Uno)
                           .Where(d => d.GuildId == guildIdx)
                           .FirstOrDefault();

            if (tryGuild is not null) { return "req"; }

            return string.Empty;
        }

        /// <summary>
        /// Checks if a guild application exists from the given user's session and guild index.
        /// </summary>
        /// <param name="guild">The Guild.</param>
        /// <param name="session">The session of the user.</param>
        /// <returns>'req' if the user has applied to join the guild, otherwise an empty string.</returns>
        public RoGuild Guild2RoGuild(GuildScheme guild, string session)
        {
            string isApplyingForGuild = GuildApplicationFromGuildId(session, guild.GuildId);

            RoGuild RoGuild = new()
            {
                apnt = guild.AlliancePoint,
                cnt = guild.Count,
                emb = guild.Emblem,
                gidx = guild.GuildId,
                gnm = guild.Name,
                gtyp = guild.GuildType,
                lev = guild.Level,
                list = isApplyingForGuild,
                mxCnt = guild.MaxCount,
                ntc = guild.Notice,
                world = guild.World,
            };

            return RoGuild;
        }

        /// <summary>
        /// Retrieves the guild application from the given user's unique identifier.
        /// </summary>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <returns>The unique identifier of the guild if an application exists, otherwise 0.</returns>
        public int RetrieveGuildApplicationFromId(int uno)
        {
            var tryGuild = DatabaseCollection.AsQueryable()
                           .Where(d => d.Uno == uno)
                           .FirstOrDefault();

            return tryGuild.GuildId;
        }

        /// <summary>
        /// Checks if any guild application exists for the given user session.
        /// </summary>
        /// <param name="session">The session identifier of the user.</param>
        /// <returns>
        /// "reg" if a guild application exists for the user,
        /// otherwise an empty string.
        /// </returns>
        public string CheckIfAnyApplicationExists(string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user is null) { return string.Empty; }

            var tryGuild = DatabaseCollection.AsQueryable()
                           .Where(d => d.Uno == user.Uno)
                           .FirstOrDefault();

            if (tryGuild is not null) { return "reg"; }

            return string.Empty;
        }

        /// <summary>
        /// Deletes a guild application for the specified user and guild.
        /// </summary>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <param name="guildIdx">The unique identifier of the guild.</param>
        /// <returns>True if the guild application is successfully deleted, otherwise false.</returns>
        public bool DeleteGuildApplication(int uno, int guildIdx)
        {
            var filter = Builders<GuildApplicationScheme>.Filter.And(Builders<GuildApplicationScheme>.Filter.Eq("Uno", uno),
            Builders<GuildApplicationScheme>.Filter.Eq("GuildId", guildIdx));

            var result = DatabaseCollection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }

        /// <summary>
        /// Retrieves a list of guild applications for the specified guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <returns>A list of member data representing guild applications.</returns>
        public List<GuildMember.MemberData> GetGuildApplications(int? guildId)
        {
            var guilds = new List<GuildMember.MemberData>();

            var filter = Builders<GuildApplicationScheme>.Filter.Eq("GuildId", guildId);

            List<GuildApplicationScheme> matchingEntries = DatabaseCollection.Find(filter).ToList();

            foreach (var entry in matchingEntries)
            {
                guilds.Add(entry.JoinMemberData);
            }

            return guilds;
        }

        /// <summary>
        /// Declines a guild join request for the specified member.
        /// </summary>
        /// <param name="uno">The unique identifier of the member whose request is to be declined.</param>
        /// <returns>The error code indicating the result of the operation.</returns>
        public ErrorCode DeclineGuildJoinRequest(int uno)
        {
            var guildId = RetrieveGuildApplicationFromId(uno);

            var guild = DatabaseManager.Guild.FindByUid(guildId);

            if (guild.Count == guild.MaxCount)
            {
                return ErrorCode.FederationIsFull;
            }

            var application = FindApplicationByUno(uno, guildId);

            var user = DatabaseManager.GameProfile.FindByUno(uno);

            if (CheckIfRequestMemberDataChanged(application, user))
            {
                return ErrorCode.RequestDataHasBeenChanged;
            }

#warning TODO
            // blablabla if federation settings change blabla
            // add thing here

            DeleteGuildApplication(uno, guildId);

            return ErrorCode.Success;
        }

        /// <summary>
        /// Approves a guild join request for the specified member.
        /// </summary>
        /// <param name="uno">The unique identifier of the member whose request is to be approved.</param>
        /// <returns>The error code indicating the result of the operation.</returns>
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

            if (CheckIfRequestMemberDataChanged(application, user))
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

        /// <summary>
        /// Checks if the data of the member requesting to join the guild has changed since the application.
        /// </summary>
        /// <param name="guildApplication">The guild application data of the member.</param>
        /// <param name="user">The profile data of the member.</param>
        /// <returns>True if the data has changed; otherwise, false.</returns>
        private bool CheckIfRequestMemberDataChanged(GuildApplicationScheme guildApplication, GameProfileScheme user)
        {
            return guildApplication.JoinMemberData.thumnail != user.Resources.thumbnailId || guildApplication.JoinMemberData.level != user.Resources.level || guildApplication.JoinMemberData.name != user.Resources.nickname || user.GuildId is not null;
        }
    }
}