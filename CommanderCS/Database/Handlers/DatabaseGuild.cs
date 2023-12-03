using MongoDB.Bson;
using MongoDB.Driver;
using CommanderCS.Database.Schemes;
using CommanderCS.Host;
using CommanderCS.Protocols;
using CommanderCS.Ro;
using CommanderCS.Utils;
using System;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using CommanderCSLibrary.Utils;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseGuild : DatabaseTable<GuildScheme>
    {
        public DatabaseGuild() : base("Guild ")
        {
        }

        public void Create(string guildname, int emblem, int guildtype, int levellimit, string session)
        {
            int guildId = DatabaseManager.AutoIncrements.GetNextNumber("GuildId", 1000);

            double time = TimeManager.CurrentEpochMilliseconds;

            var user = DatabaseManager.GameProfile.FindBySession(session);

            // TODO PROBABLY NEEDS AN OVERHAUL OR SO IDK

            GuildScheme guild = new()
            {
                GuildId = guildId,
                Name = guildname,
                Emblem = emblem,
                GuildType = guildtype,
                Limitlevel = levellimit,
                CreateTime = time,
                Level = 1,
                Count = 1,
                MemberData =
                [
                    new()
                    {
                        level = user.UserResources.level,
                        lastTime = 0,
                        memberGrade = 1,
                        name = user.UserResources.nickname,
                        paymentBonusPoint = 0,
                        thumnail = user.UserResources.thumbnailId,
                        todayPoint = 0,
                        totalPoint = 0,
                        uno = user.Uno,
                        world = user.Server,
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
                aPoint = 0,
                Point = 0,
                MemberGrade = 0,
                MaxCount = 20,
                BoardList = [],
                // MemberGrade 1 = Guildmaster 
                // MemberGrade 2 = Sub Guildmaster
                LastGuildEdit = TimeManager.CurrentEpochMilliseconds,
            };

            DatabaseManager.GameProfile.UpdateGuildId(user.Uno, guildId);

            DatabaseCollection.InsertOne(guild);
        }

        public GuildScheme FindByName(string guildName)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Name == guildName).FirstOrDefault();
        }
        public GuildScheme FindByUid(int? guildId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();
        }


        public int GetMemberGrade(int? guildId, int uno)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault().MemberData.Where(d => d.uno == uno).FirstOrDefault().memberGrade;
        }
        public UserInformationResponse.UserGuild RequestGuild(int? guildId, int uno)
        {
            if (guildId == null)
            {
                return null;
            }

            GuildScheme? guild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild == null)
            {
                return null;
            }

            var guildMember = guild.MemberData.Where(member => member.uno == uno).FirstOrDefault();


            if (guildMember == null)
            {
                return null;
            }

            UserInformationResponse.UserGuild userGuild = new()
            {
                skillDada = guild.SkillDada,
                state = guild.State,
                aPoint = guild.aPoint,
                closeTime = guild.CloseTime,
                count = guild.Count,
                createTime = guild.CreateTime,
                emblem = guild.Emblem,
                guildType = guild.GuildType,
                idx = guild.GuildId,
                level = guild.Level,
                limitLevel = guild.Limitlevel,
                maxCount = guild.MaxCount,
                memberGrade = guildMember.memberGrade,
                name = guild.Name,
                notice = guild.Notice,
                occupy = guild.Occupy,
                point = guild.Point,
                world = guild.World,  
            };


            return userGuild;
        }
        public List<GuildMember.MemberData> RequestGuildMembers(int? guildId)
        {
            if (guildId == null)
            {
                return null;
            }

            GuildScheme? guild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild == null)
            {
                return null;
            }

            foreach(var entry in guild.MemberData)
            {
                var user = DatabaseManager.GameProfile.FindByUno(entry.uno);

                entry.lastTime = TimeManager.GetTimeDifference(user.LastLoginTime);

                entry.level = user.UserResources.level;
                entry.name = user.UserResources.nickname;
            }

            return guild.MemberData;
        }
        public void UpdateGuildName(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Name", val);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void UpdateGuildEmblem(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Emblem", int.Parse(val));

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void UpdateGuildType(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("GuildType", int.Parse(val));

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void UpdateLimitLevel(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Limitlevel", int.Parse(val));

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void UpdateGuildNotice(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Notice", val);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public List<RoGuild> GetAllGuilds(string session)
        {
            var allGuilds = DatabaseCollection.AsQueryable().ToList();

            if (allGuilds == null)
            {
                return null;
            }

            List<RoGuild> returnGuilds = [];

            foreach (var guild in allGuilds)
            {
                string isApplyingForGuild = DatabaseManager.GuildApplication.RetrieveGuildApplication(session, guild.GuildId);

                RoGuild newGuild = new()
                {
                    apnt = guild.aPoint,
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
        public List<GuildBoardData> GetGuildBoard(int? guildId, out ErrorCode code)
        {
            GuildScheme? guild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

#warning add the blabla for ErrorCode.FederationSettingsChangedWhileGettingGuildBoard

            code = ErrorCode.Success;

            return guild.BoardList;
        }
        public void AddGuildBoardEntry(int? guildId, GuildBoardData guildBoardData)
        {
            GuildScheme? guild = DatabaseCollection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild != null)
            {
                if (guild.BoardList == null)
                {
                    guild.BoardList = [];
                }

                guild.BoardList.Add(guildBoardData);
            }

            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("BoardList", guild.BoardList);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void DeleteGuildBoardEntry(int? guildId, int entryId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var guildBoardFilter = Builders<GuildBoardData>.Filter.Eq("idx", entryId);
            var update = Builders<GuildScheme>.Update.PullFilter("BoardList", guildBoardFilter);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public ErrorCode UpdateGuildInfo(int act, string val, string session)
        {

            if (Misc.NameCheck(val))
            {
                return ErrorCode.FederationNameContainsBadwordsOrInvalid;
            }

            if(act == 0)
            {
                if (FindByName(val) != null)
                {
                    return ErrorCode.FederationNameAlreadyExists;
                }
            }

            var user = DatabaseManager.GameProfile.FindBySession(session);

            var guild = FindByUid(user.GuildId);

            //DateTime currentTime = DateTime.UtcNow;
            //DateTime lastGuildEditTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(guild.LastGuildEdit);
            
            //TimeSpan timeDifference = lastGuildEditTime - currentTime;

            //if (timeDifference.TotalSeconds <= 30)
            //{
            //    return ErrorCode.FederationSettingsChangedRecently_2;
            //}

            switch (act)
            { 
                case 0:                  
                    UpdateGuildName(guild.GuildId, val);
                    DatabaseManager.GameProfile.UpdateCash(user.Session, 500, false);
                    break;
                case 1:
                    UpdateGuildEmblem(guild.GuildId, val);
                    DatabaseManager.GameProfile.UpdateCash(user.Session, 100, false);
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
        public void AddFreeJoinGuildMember(int uno, int guildId)
        {
            var user = DatabaseManager.GameProfile.FindByUno(uno);

            var memberData = new GuildMember.MemberData()
            {
                memberGrade = 0,
                lastTime = 0,
                level = user.UserResources.level,
                name = user.UserResources.nickname,
                paymentBonusPoint = 0,
                thumnail = user.UserResources.thumbnailId,
                todayPoint = 0,
                totalPoint = 0,
                uno = user.Uno,
                world = user.Server,
            };

            var guild = FindByUid(guildId);


            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Push("MemberData", memberData).Set("Count", guild.MemberData.Count + 1);

            DatabaseManager.GameProfile.UpdateGuildId(uno, guildId);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void AddGuildMember(int uno, int guildId, GuildMember.MemberData member)
        {       
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Push("MemberData", member);

            DatabaseManager.GameProfile.UpdateGuildId(uno, guildId);

            DatabaseCollection.UpdateOne(filter, update);

            var guildCount = FindByUid(guildId).Count;

            var filter2 = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update2 = Builders<GuildScheme>.Update.Set("Count", guildCount++);

            DatabaseCollection.UpdateOne(filter2, update2);
        }
        public bool AppointSubMaster(int uno, int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", 2);

            var result = DatabaseCollection.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }
        public int GetTotalSubMasters(int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<GuildMember.MemberData>.Filter.Eq("memberGrade", 2));

            var count = DatabaseCollection.CountDocuments(filter);

            return (int)count;
        }
        public void UpdateGuildPointLevelMaxCount(int? GuildId, GuildScheme guild)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", GuildId);

            var update = Builders<GuildScheme>.Update.Set("Point", guild.Point).Set("Level", guild.Level).Set("MaxCount",guild.MaxCount);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void UpdateGuildSkill(int? guildId, List<UserInformationResponse.UserGuild.GuildSkill> SkillDada, int newPoint)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("SkillDada", SkillDada).Set("Point", newPoint);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void CloseDownGuild(int? guildId, double closeTime)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("State", 1).Set("CloseTime", closeTime);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public void ResetMemberGrades(int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.And(
                Builders<GuildScheme>.Filter.Eq("GuildId", guildId),
                Builders<GuildScheme>.Filter.ElemMatch("MemberData", Builders<GuildMember.MemberData>.Filter.Gt("memberGrade", 0))
            );

            var update = Builders<GuildScheme>.Update.Set("MemberData.$[elem].memberGrade", 0);

            var arrayFilters = new List<ArrayFilterDefinition>{ new JsonArrayFilterDefinition<GuildMember.MemberData>("{'elem.memberGrade': {$gt: 0}}") };

            var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

            DatabaseCollection.UpdateMany(filter, update, updateOptions);
        }
        public void AppointNewGuildMaster(int? guildId, int uno, int tuno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));

            var updateUno = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", 0);

            DatabaseCollection.UpdateOne(filter, updateUno);

            var filterTuno = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                              & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                                  Builders<GuildMember.MemberData>.Filter.Eq("uno", tuno));

            var updateTuno = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", 1);

            DatabaseCollection.UpdateOne(filterTuno, updateTuno);
        }
        public void UpdateSpecificMemberGrade(int? guildId, int uno, int memberGrade)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", memberGrade);

            DatabaseCollection.UpdateOne(filter, update);
        }
        public bool IsUnoInMemberData(int? guildId, int uno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId) & Builders<GuildScheme>.Filter.ElemMatch("MemberData", Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));

            long count = DatabaseCollection.CountDocuments(filter);

            return count > 0;
        }

        public void QuitGuild(int? guildId, int uno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.PullFilter("MemberData", Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));
            DatabaseCollection.UpdateOne(filter, update);

            var user = DatabaseManager.GameProfile.FindByUno(uno);
            if (user != null && user.GuildId == guildId)
            {
                DatabaseManager.GameProfile.UpdateGuild(uno, null);
            }

            var guildCount = FindByUid(guildId).MemberData.Count;
            var filter2 = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update2 = Builders<GuildScheme>.Update.Set("Count", guildCount);
            DatabaseCollection.UpdateOne(filter2, update2);
        }

        public bool RemoveMemberDataByUno(int? guildId, int uno)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId) & Builders<GuildScheme>.Filter.ElemMatch("MemberData", Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.PullFilter("MemberData", Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));

            var result = DatabaseCollection.UpdateOne(filter, update);

            var user = DatabaseManager.GameProfile.FindByUno(uno);

            if (user != null && user.GuildId == guildId)
            {
                DatabaseManager.GameProfile.UpdateGuild(uno, null);
            }

            var guildCount = FindByUid(guildId).MemberData.Count;
            var filter2 = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update2 = Builders<GuildScheme>.Update.Set("Count", guildCount);
            DatabaseCollection.UpdateOne(filter2, update2);

            return result.ModifiedCount > 0;
        }
    }
}