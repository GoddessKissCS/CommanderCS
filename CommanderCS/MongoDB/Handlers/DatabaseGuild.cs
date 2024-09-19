using CommanderCS.Host;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Ro;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing guild information.
    /// </summary>
    public class DatabaseGuild : DatabaseTable<GuildScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseGuild"/> class.
        /// </summary>
        public DatabaseGuild() : base("Guild")
        {
        }

        /// <summary>
        /// Creates a new guild with the specified parameters.
        /// </summary>
        /// <param name="session">The session of the user creating the guild.</param>
        /// <param name="guildname">The name of the guild.</param>
        /// <param name="emblem">The emblem of the guild.</param>
        /// <param name="guildtype">The type of the guild.</param>
        /// <param name="levellimit">The level limit of the guild.</param>
        public void Create(string session, string guildname, int emblem, int guildtype, int levellimit)
        {
            int guildId = DatabaseManager.AutoIncrements.GetNextNumber("GuildId");

            double time = TimeManager.CurrentEpochMilliseconds;

            var user = DatabaseManager.GameProfile.FindBySession(session);

            // TODO PROBABLY NEEDS AN OVERHAUL OR SO IDK

            GuildScheme guild = new()
            {
                GuildId = guildId,
                Name = guildname,
                Emblem = emblem,
                GuildType = guildtype,
                LimitLevel = levellimit,
                CreateTime = time,
                Level = 1,
                Count = 1,
                MemberData =
                [
                    new()
                    {
                        Level = user.UserResources.level,
                        LastTime = time,
                        JoinDate = time,
                        MemberGrade = 1,
                        Name = user.UserResources.nickname,
                        PaymentBonusPoint = 0,
                        Thumbnail = user.UserResources.thumbnailId,
                        TodayPoint = 0,
                        TotalPoint = 0,
                        Uno = user.Uno,
                        World = user.Server,
                    }
                ],
                Notice = string.Empty,
                State = 0,
                SkillDada = [
                    new()
                    {
                        idx = 1,
                        level = 0,
                    },
                    new()
                    {
                        idx = 2,
                        level = 0,
                    },
                    new()
                    {
                        idx = 3,
                        level = 0,
                    },
                    new()
                    {
                        idx = 8,
                        level = 0,
                    },
                    new()
                    {
                        idx = 9,
                        level = 0,
                    },
                    new()
                    {
                        idx = 10,
                        level = 0,
                    },
                ],
                World = user.Server,
                AlliancePoint = 0,
                Point = 0,
                MaxCount = 20,
                BoardListData = [],
                LastEdit = null,
            };

            DatabaseManager.GameProfile.UpdateGuildId(user.Uno, guildId);

            DatabaseCollection.InsertOne(guild);
        }

        /// <summary>
        /// Finds a guild by its name.
        /// </summary>
        /// <param name="guildName">The name of the guild to find.</param>
        /// <returns>The guild with the specified name, or null if not found.</returns>
        public GuildScheme FindByName(string guildName)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Name == guildName).FirstOrDefault();
        }

        /// <summary>
        /// Finds a guild by its unique identifier.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild to find.</param>
        /// <returns>The guild with the specified unique identifier, or null if not found.</returns>
        public GuildScheme FindByUid(int? guildId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();
        }

        /// <summary>
        /// Finds the guild associated with the specified session.
        /// </summary>
        /// <param name="session">The session identifier of the user.</param>
        /// <returns>The guild associated with the specified session, or null if not found.</returns>
        public GuildScheme FindBySession(string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            return DatabaseCollection.AsQueryable().Where(d => d.GuildId == user.GuildId).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the member grade of a user in a guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <returns>The member grade of the user in the guild.</returns>
        public int GetMemberGrade(int? guildId, int uno)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault().MemberData.Where(d => d.Uno == uno).FirstOrDefault().MemberGrade;
        }

        /// <summary>
        /// Creates a new guild with the provided information.
        /// </summary>
        /// <param name="session">The session of the user creating the guild.</param>
        /// <param name="guildName">The name of the guild.</param>
        /// <param name="emblem">The emblem of the guild.</param>
        /// <param name="guildType">The type of the guild.</param>
        /// <param name="guildLevelLimit">The level limit of the guild.</param>
        /// <returns>The guild information after creation.</returns>
        public GuildInfo CreateGuild(string session, string guildName, int emblem, int guildType, int guildLevelLimit)
        {
            DatabaseManager.GameProfile.UpdateOnlyCash(session, RemoteObjectManager.DefineDataTable.GUILD_CREATION_PRICE, false);

            Create(session, guildName, emblem, guildType, guildLevelLimit);

            var user = DatabaseManager.GameProfile.FindBySession(session);

            var rsoc = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);

            var userguild = RequestGuild(user.GuildId, user.Uno);

            var memberdata = RequestGuildMembers(user.GuildId);

            GuildInfo guildInfo = new()
            {
                guildInfo = userguild,
                resource = rsoc,
                memberData = memberdata
            };

            return guildInfo;
        }

        /// <summary>
        /// Retrieves the information about the guild associated with the given guild ID and user UNO.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="uno">The UNO of the user.</param>
        /// <returns>The information about the guild.</returns>
        public UserInformationResponse.UserGuild RequestGuild(int? guildId, int uno)
        {
            if (guildId is null)
            {
                return null;
            }

            GuildScheme? requestGuild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (requestGuild is null)
            {
                return null;
            }

            var requestMember = requestGuild.MemberData.Where(member => member.Uno == uno).FirstOrDefault();

            if (requestMember is null)
            {
                return null;
            }

            UserInformationResponse.UserGuild userGuild = new()
            {
                skillDada = requestGuild.SkillDada,
                state = requestGuild.State,
                aPoint = requestGuild.AlliancePoint,
                closeTime = requestGuild.CloseTime,
                count = requestGuild.Count,
                createTime = requestGuild.CreateTime,
                emblem = requestGuild.Emblem,
                guildType = requestGuild.GuildType,
                idx = requestGuild.GuildId,
                level = requestGuild.Level,
                limitLevel = requestGuild.LimitLevel,
                maxCount = requestGuild.MaxCount,
                memberGrade = requestMember.MemberGrade,
                name = requestGuild.Name,
                notice = requestGuild.Notice,
                occupy = requestGuild.Occupy,
                point = requestGuild.Point,
                world = requestGuild.World,
            };

            return userGuild;
        }

        /// <summary>
        /// Retrieves the list of guild members associated with the given guild ID.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <returns>The list of guild members.</returns>
        public List<GuildMember.MemberData> RequestGuildMembers(int? guildId)
        {
            if (guildId is null)
            {
                return null;
            }

            GuildScheme? guild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild is null)
            {
                return null;
            }

            List<GuildMember.MemberData> memberData = [];

            foreach (var member in guild.MemberData)
            {
                var user = DatabaseManager.GameProfile.FindByUno(member.Uno);

                var lastTime = TimeManager.GetTimeDifference(user.LastLoginTime);

                GuildMember.MemberData guildMember = new()
                {
                    lastTime = lastTime,
                    level = user.UserResources.level,
                    name = user.UserResources.nickname,
                    world = member.World,
                    uno = member.Uno,
                    thumnail = member.Thumbnail,
                    memberGrade = member.MemberGrade,
                    paymentBonusPoint = member.PaymentBonusPoint,
                    todayPoint = member.TodayPoint,
                    totalPoint = member.TotalPoint
                };

                memberData.Add(guildMember);
            }

            return memberData;
        }

        /// <summary>
        /// Updates the name of the guild with the specified guild ID.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="newGuildName">The new name for the guild.</param>
        public void UpdateGuildName(int guildId, string newGuildName)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("Name", newGuildName);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the emblem of the guild with the specified guild ID.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="emblemId">The new emblem ID for the guild.</param>
        public void UpdateGuildEmblem(int guildId, string emblemId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("Emblem", int.Parse(emblemId));

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the type of the guild with the specified guild ID.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="guildType">The new type for the guild.</param>
        public void UpdateGuildType(int guildId, string guildType)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("GuildType", int.Parse(guildType));

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the level limit of the guild with the specified guild ID.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="newLimitLevel">The new level limit for the guild.</param>
        public void UpdateLimitLevel(int guildId, string newLimitLevel)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("Limitlevel", int.Parse(newLimitLevel));

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the notice of the guild with the specified guild ID.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="newGuildNotice">The new notice for the guild.</param>
        public void UpdateGuildNotice(int guildId, string newGuildNotice)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("Notice", newGuildNotice);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Retrieves a list of guilds with limited count.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <returns>A list of guilds with limited count.</returns>
        public List<RoGuild> GetAllGuilds(string session)
        {
            var allGuilds = DatabaseCollection.AsQueryable().Take(20).ToList();

            if (allGuilds is null)
            {
                return null;
            }

            List<RoGuild> returnGuilds = [];

            foreach (var guild in allGuilds)
            {
                string isApplyingForGuild = DatabaseManager.GuildApplication.GuildApplicationFromGuildId(session, guild.GuildId);

                RoGuild newGuild = new()
                {
                    apnt = guild.AlliancePoint,
                    cnt = guild.Count,
                    mxCnt = guild.MaxCount,
                    gidx = guild.GuildId,
                    gnm = guild.Name,
                    gtyp = guild.GuildType,
                    emb = guild.Emblem,
                    lev = guild.Level,
                    ntc = guild.Notice,
                    world = guild.World,
                    list = isApplyingForGuild,
                };

                returnGuilds.Add(newGuild);
            }

            return returnGuilds;
        }

        /// <summary>
        /// Retrieves the guild board data for a specific guild.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="code">An out parameter representing the error code.</param>
        /// <returns>The list of guild board data.</returns>
        public List<GuildBoardData> GetGuildBoard(int? guildId, out ErrorCode code)
        {
            GuildScheme? guild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

#warning add the blabla for ErrorCode.FederationSettingsChangedWhileGettingGuildBoard

            code = ErrorCode.Success;

            return guild.BoardListData;
        }

        /// <summary>
        /// Adds a new entry to the guild board for a specific guild.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="guildBoardData">The guild board data to add.</param>
        public void AddGuildBoardEntry(int? guildId, GuildBoardData guildBoardData)
        {
            GuildScheme? guild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild is not null)
            {
                if (guild.BoardListData is null)
                {
                    guild.BoardListData = [];
                }

                guild.BoardListData.Add(guildBoardData);
            }

            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("BoardList", guild.BoardListData);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Deletes a specific entry from the guild board of a guild.
        /// </summary>
        /// <param name="guildId">The ID of the guild.</param>
        /// <param name="entryId">The ID of the entry to delete.</param>
        public void DeleteGuildBoardEntry(int? guildId, int entryId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var guildBoardFilter = Builders<GuildBoardData>.Filter.Eq("idx", entryId);
            var update = Builders<GuildScheme>.Update.PullFilter("BoardList", guildBoardFilter);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the guild information based on the action and value provided.
        /// </summary>
        /// <param name="session">The session of the user initiating the update.</param>
        /// <param name="act">The action to perform:
        /// 0 for updating guild name,
        /// 1 for updating guild emblem,
        /// 2 for updating guild level limit,
        /// 3 for updating guild type,
        /// 4 for updating guild notice.</param>
        /// <param name="val">The new value to set for the specified action.</param>
        /// <returns>An ErrorCode indicating the result of the update operation.</returns>
        public ErrorCode UpdateGuildInfo(string session, int act, string val)
        {
            if (Misc.NameCheck(val))
            {
                return ErrorCode.FederationNameContainsBadwordsOrIsInvalid;
            }

            if (act == 0)
            {
                if (FindByName(val) is not null)
                {
                    return ErrorCode.FederationNameAlreadyExists;
                }
            }

            var user = DatabaseManager.GameProfile.FindBySession(session);

            var guild = FindByUid(user.GuildId);

            if (guild.LastEdit is not null)
            {
                double time = (double)guild.LastEdit;

                var timeDifference = TimeManager.GetTimeDifference(time);

                if (timeDifference < 30)
                {
                    return ErrorCode.FederationSettingsChangedRecently_2;
                }
            }

            switch (act)
            {
                case 0:
                    UpdateGuildName(guild.GuildId, val);
                    DatabaseManager.GameProfile.UpdateOnlyCash(user.Session, RemoteObjectManager.DefineDataTable.GUILD_NAME_CHANGE_PRICE, false);
                    break;

                case 1:
                    UpdateGuildEmblem(guild.GuildId, val);
                    DatabaseManager.GameProfile.UpdateOnlyCash(user.Session, RemoteObjectManager.DefineDataTable.GUILD_EMBLEM_CHANGE_PRICE, false);
                    break;

                case 2:
                    UpdateLimitLevel(guild.GuildId, val);
                    break;

                case 3:
                    UpdateGuildType(guild.GuildId, val);
                    break;

                case 4:
                    UpdateGuildNotice(guild.GuildId, val);
                    break;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// Adds a free-join guild member to the specified guild.
        /// </summary>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <param name="guildId">The unique identifier of the guild.</param>
        public void AddFreeJoinGuildMember(int uno, int guildId)
        {
            var user = DatabaseManager.GameProfile.FindByUno(uno);

            var time = TimeManager.CurrentEpoch;

            var memberData = new MemberData()
            {
                MemberGrade = 0,
                LastTime = time,
                JoinDate = time,
                Level = user.UserResources.level,
                Name = user.UserResources.nickname,
                PaymentBonusPoint = 0,
                Thumbnail = user.UserResources.thumbnailId,
                TodayPoint = 0,
                TotalPoint = 0,
                Uno = user.Uno,
                World = user.Server,
            };

            var guild = FindByUid(guildId);

            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Push("MemberData", memberData).Set("Count", guild.MemberData.Count + 1);

            DatabaseManager.GameProfile.UpdateGuildId(uno, guildId);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Adds a guild member to the specified guild.
        /// </summary>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="member">The member data to be added.</param>
        public void AddGuildMember(int uno, int guildId, GuildMember.MemberData member)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Push("MemberData", member);

            DatabaseManager.GameProfile.UpdateGuildId(uno, guildId);

            DatabaseCollection.UpdateOne(filter, update);

            var guildCount = FindByUid(guildId).MemberData.Count;

            var filter2 = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update2 = Builders<GuildScheme>.Update.Set("Count", guildCount);

            DatabaseCollection.UpdateOne(filter2, update2);
        }

        /// <summary>
        /// Appoints a sub-master for the specified user in the guild.
        /// </summary>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <returns>True if the appointment is successful; otherwise, false.</returns>
        public bool AppointSubMaster(int uno, int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", 2);

            var result = DatabaseCollection.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }

        /// <summary>
        /// Gets the total number of sub-masters in the guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <returns>The total number of sub-masters.</returns>
        public int GetTotalSubMasters(int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<MemberData>.Filter.Eq("memberGrade", 2));

            var count = DatabaseCollection.CountDocuments(filter);

            return (int)count;
        }

        /// <summary>
        /// Updates the guild's point, level, and maximum count.
        /// </summary>
        /// <param name="GuildId">The unique identifier of the guild.</param>
        /// <param name="guild">The updated guild information.</param>
        public void UpdateGuildPointLevelMaxCount(int? GuildId, GuildScheme guild)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", GuildId);

            var update = Builders<GuildScheme>.Update.Set("Point", guild.Point).Set("Level", guild.Level).Set("MaxCount", guild.MaxCount);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the guild's skills and points.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="SkillDada">The updated list of guild skills.</param>
        /// <param name="newPoint">The new point value for the guild.</param>
        public void UpdateGuildSkill(int? guildId, List<UserInformationResponse.UserGuild.GuildSkill> SkillDada, int newPoint)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("SkillDada", SkillDada).Set("Point", newPoint);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Closes down the specified guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="closeTime">The time at which the guild is closed down.</param>
        public void CloseDownGuild(int? guildId, double closeTime)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("State", 1).Set("CloseTime", closeTime);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Resets the member grades of all members in the specified guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        public void ResetMemberGrades(int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.And(
                Builders<GuildScheme>.Filter.Eq("GuildId", guildId),
                Builders<GuildScheme>.Filter.ElemMatch("MemberData", Builders<MemberData>.Filter.Gt("memberGrade", 0))
                                                         );

            var update = Builders<GuildScheme>.Update.Set("MemberData.$[elem].memberGrade", 0);

            var arrayFilters = new List<ArrayFilterDefinition> { new JsonArrayFilterDefinition<MemberData>("{'elem.memberGrade': {$gt: 0}}") };

            var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

            DatabaseCollection.UpdateMany(filter, update, updateOptions);
        }

        /// <summary>
        /// Appoints a new guild master by transferring the role from one member to another.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="uno">The unique identifier of the current guild master.</param>
        /// <param name="tuno">The unique identifier of the member who will become the new guild master.</param>
        public void AppointNewGuildMaster(int? guildId, int uno, int tuno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<MemberData>.Filter.Eq("uno", uno));

            var updateUno = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", 0);

            DatabaseCollection.UpdateOne(filter, updateUno);

            var filterTuno = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                             & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                                   Builders<MemberData>.Filter.Eq("uno", tuno));

            var updateTuno = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", 1);

            DatabaseCollection.UpdateOne(filterTuno, updateTuno);
        }

        /// <summary>
        /// Updates the grade of a specific member within the guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="uno">The unique identifier of the member whose grade will be updated.</param>
        /// <param name="memberGrade">The new grade to assign to the member.</param>
        public void UpdateSpecificMemberGrade(int? guildId, int uno, int memberGrade)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", memberGrade);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Checks if a member with the specified unique identifier (UNO) exists within the guild's member data.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="uno">The unique identifier of the member to check.</param>
        /// <returns><c>true</c> if the member exists in the guild's member data; otherwise, <c>false</c>.</returns>
        public bool IsUnoInMemberData(int? guildId, int uno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId) & Builders<GuildScheme>.Filter.ElemMatch("MemberData", Builders<MemberData>.Filter.Eq("uno", uno));

            long count = DatabaseCollection.CountDocuments(filter);

            return count > 0;
        }

        /// <summary>
        /// Removes a member from the guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="uno">The unique identifier of the member to remove.</param>
        public void QuitGuild(int? guildId, int uno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.PullFilter("MemberData", Builders<MemberData>.Filter.Eq("uno", uno));
            DatabaseCollection.UpdateOne(filter, update);

            var user = DatabaseManager.GameProfile.FindByUno(uno);
            if (user is not null && user.GuildId == guildId)
            {
                DatabaseManager.GameProfile.UpdateGuild(uno, null);
            }

            var guildCount = FindByUid(guildId).MemberData.Count;
            var filter2 = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update2 = Builders<GuildScheme>.Update.Set("Count", guildCount);
            DatabaseCollection.UpdateOne(filter2, update2);
        }

        /// <summary>
        /// Removes a member from the guild by their unique identifier.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="uno">The unique identifier of the member to remove.</param>
        /// <returns>True if the member was successfully removed; otherwise, false.</returns>
        public bool RemoveMemberDataByUno(int? guildId, int uno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId) & Builders<GuildScheme>.Filter.ElemMatch("MemberData", Builders<MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.PullFilter("MemberData", Builders<MemberData>.Filter.Eq("uno", uno));

            var result = DatabaseCollection.UpdateOne(filter, update);

            var user = DatabaseManager.GameProfile.FindByUno(uno);

            if (user is not null && user.GuildId == guildId)
            {
                DatabaseManager.GameProfile.UpdateGuild(uno, null);
            }

            var guildCount = FindByUid(guildId).MemberData.Count;
            var filter2 = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update2 = Builders<GuildScheme>.Update.Set("Count", guildCount);
            DatabaseCollection.UpdateOne(filter2, update2);

            return result.ModifiedCount > 0;
        }

        /// <summary>
        /// Updates the thumbnail of a specific member in the guild.
        /// </summary>
        /// <param name="guildId">The unique identifier of the guild.</param>
        /// <param name="uno">The unique identifier of the member whose thumbnail to update.</param>
        /// <param name="costumeId">The new thumbnail ID to set for the member.</param>
        public void UpdateSpecificMemberThumbnail(int? guildId, int uno, int costumeId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.Set("MemberData.$.thumnail", costumeId);

            DatabaseCollection.UpdateOne(filter, update);
        }
    }
}