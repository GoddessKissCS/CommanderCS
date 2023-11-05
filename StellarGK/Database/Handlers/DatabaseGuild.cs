using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGKLibrary.Protocols;
using StellarGKLibrary.Ro;
using StellarGKLibrary.Utils;
using System;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGuild : DatabaseTable<GuildScheme>
    {
        public DatabaseGuild() : base("Guilds")
        {
        }

        public void Create(string guildname, int emblem, int guildtype, int levellimit, string session)
        {
            int guildId = DatabaseManager.AutoIncrements.GetNextNumber("GuildId", 1000);

            int time = Utility.CurrentTimeStamp();

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
                LastGuildEdit = Utility.CurrentTimeInMilliseconds(),
            };

            user.GuildId = guildId;

            DatabaseManager.GameProfile.UpdateProfile(session, user);

            Collection.InsertOne(guild);
        }

        public GuildScheme FindByName(string guildName)
        {
            return Collection.AsQueryable().Where(d => d.Name == guildName).FirstOrDefault();
        }

        public GuildScheme FindByUid(int? guildId)
        {
            return Collection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();
        }

        public int GetMemberGrade(int? guildId, int uno)
        {
            return Collection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault().MemberData.Where(d => d.uno == uno).FirstOrDefault().memberGrade;
        }


        public UserInformationResponse.UserGuild RequestGuild(int? guildId, int uno)
        {
            if (guildId == null)
            {
                return null;
            }

            GuildScheme? guild = Collection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild == null)
            {
                return null;
            }

            var guildMember = guild.MemberData.Where(member => member.uno == uno).FirstOrDefault();

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

            GuildScheme? guild = Collection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild == null)
            {
                return null;
            }

            return guild.MemberData;
        }


        public void UpdateLoginTimeInGuild(GameProfileScheme user)
        {
            GuildScheme? guild = Collection.AsQueryable().Where(d => d.GuildId == user.GuildId).FirstOrDefault();

            if (guild == null)
            {
                return;
            }

            var filter = Builders<GuildScheme>.Filter.Eq("MemberData.uno", user.Uno);

            var update = Builders<GuildScheme>.Update.Set("MemberData.$.lastTime", 0);

            Collection.UpdateOne(filter, update);
        }


        public void UpdateGuildName(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Name", val);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateGuildEmblem(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Emblem", int.Parse(val));

            Collection.UpdateOne(filter, update);
        }

        public void UpdateGuildType(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("GuildType", int.Parse(val));

            Collection.UpdateOne(filter, update);
        }

        public void UpdateLimitLevel(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Limitlevel", int.Parse(val));

            Collection.UpdateOne(filter, update);
        }

        public void UpdateGuildNotice(int guildId, string val)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("Notice", val);

            Collection.UpdateOne(filter, update);
        }

        public List<RoGuild> GetAllGuilds(string session)
        {
            var allGuilds = Collection.AsQueryable().ToList();

            List<RoGuild> returnGuilds = [];

            if (allGuilds == null)
            {
                return null;
            }

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
            GuildScheme? guild = Collection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

#warning add the blabla for ErrorCode.FederationSettingsChangedWhileGettingGuildBoard

            code = ErrorCode.Success;

            return guild.BoardList;
        }

        public void AddGuildBoardEntry(GuildBoardData guildBoardData, int? guildId)
        {
            GuildScheme? guild = Collection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();

            if (guild != null)
            {
                // Initialize the BoardList if it's null
                if (guild.BoardList == null)
                {
                    guild.BoardList = [];
                }

                guild.BoardList.Add(guildBoardData);
            }

            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);

            var update = Builders<GuildScheme>.Update.Set("BoardList", guild.BoardList);

            Collection.UpdateOne(filter, update);
        }

        public ErrorCode UpdateGuildInfo(int act, string val, string session)
        {

            if (Misc.NameCheck(val))
            {
                return ErrorCode.FederationNameContainsBadwordsOrInvalid;
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
                case 0: // Guildname
                    
                    if (FindByName(val) != null)
                    {
                        return ErrorCode.FederationNameAlreadyExists;
                    }

                    UpdateGuildName(guild.GuildId, val);

                    DatabaseManager.GameProfile.UpdateCash(user.Session, 500, false);
                    break;
                case 1: // emblem
                    UpdateGuildEmblem(guild.GuildId, val);
                    DatabaseManager.GameProfile.UpdateCash(user.Session, 100, false);
                    break;
                case 2: // limitLevel
                    UpdateLimitLevel(guild.GuildId, val);
                    break;
                case 3: // guildType
                    UpdateGuildType(guild.GuildId, val);
                    break;
                case 4: // Notice
                    UpdateGuildNotice(guild.GuildId, val);
                    break;
            }

            return ErrorCode.Success;
        }


        public void AddGuildMember(int uno, int guildId, GuildMember.MemberData member)
        {       
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Push("MemberData", member);

            DatabaseManager.GameProfile.UpdateGuildId(uno, guildId);

            Collection.UpdateOne(filter, update);

            var guild = FindByUid(guildId);

            var filter2 = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update2 = Builders<GuildScheme>.Update.Set("Count", guild.MemberData.Count);

            Collection.UpdateOne(filter2, update2);
        }

        public bool AppointSubMaster(int uno, int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<GuildMember.MemberData>.Filter.Eq("uno", uno));

            var update = Builders<GuildScheme>.Update.Set("MemberData.$.memberGrade", 2);

            var result = Collection.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }

        public int GetTotalSubMasters(int? guildId)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId)
                         & Builders<GuildScheme>.Filter.ElemMatch("MemberData",
                             Builders<GuildMember.MemberData>.Filter.Eq("memberGrade", 2));

            var count = Collection.CountDocuments(filter);

            return (int)count;
        }

        public void UpdateGuildPointLevelMaxCount(int? GuildId, GuildScheme guild)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", GuildId);

            var update = Builders<GuildScheme>.Update.Set("Point", guild.Point).Set("Level", guild.Level).Set("MaxCount",guild.MaxCount);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateGuildSkill(int? guildId, List<UserInformationResponse.UserGuild.GuildSkill> SkillDada, int newPoint)
        {
            var filter = Builders<GuildScheme>.Filter.Eq("GuildId", guildId);
            var update = Builders<GuildScheme>.Update.Set("SkillDada", SkillDada).Set("Point", newPoint);

            Collection.UpdateOne(filter, update);
        }

    }
}