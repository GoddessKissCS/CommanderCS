using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGKLibrary.Protocols;
using StellarGKLibrary.Ro;
using StellarGKLibrary.Utils;

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
                        // MemberGrade 1 = Guildmaster 
                        // MemberGrade 2 = Sub Guildmaster
                        name = user.UserResources.nickname,
                        paymentBonusPoint = 0,
                        thumnail = user.UserResources.thumbnailId,
                        todayPoint = 0,
                        totalPoint = 0,
                        uno = int.Parse(user.Uno),
                        world = user.Server,
                    }
                ],
                Notice = string.Empty,
                State = 0,
                SkillDada = [
                    new()
                    {
                        idx = 1,
                        level = 1,
                    },
                    new()
                    {
                        idx = 2,
                        level = 1,
                    },
                    new()
                    {
                        idx = 3,
                        level = 1,
                    },
                    new()
                    {
                        idx = 8,
                        level = 1,
                    },
                    new()
                    {
                        idx = 9,
                        level = 1,
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
            };

            user.GuildId = guildId;

            DatabaseManager.GameProfile.UpdateProfile(session, user);

            Collection.InsertOne(guild);
        }

        public GuildScheme FindByName(string guildName)
        {
            return Collection.AsQueryable().Where(d => d.Name == guildName).FirstOrDefault();
        }

        public GuildScheme FindByUid(int guildId)
        {
            return Collection.AsQueryable().Where(d => d.GuildId == guildId).FirstOrDefault();
        }

        public UserInformationResponse.UserGuild RequestGuild(int? guildId)
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
                memberGrade = guild.MemberGrade,
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
    }
}