using System.Collections.Generic;
using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGuild : DatabaseTable<GuildScheme>
    {
        public DatabaseGuild() : base("Guilds") { }

        public void Create()
        {

        }

        public GuildScheme FindByName(string guildName)
        {
            GuildScheme? guild = collection.AsQueryable().Where(d => d.name == guildName).FirstOrDefault();
            return guild;
        }
        public GuildScheme FindByUid(int guildId)
        {
            GuildScheme? guild = collection.AsQueryable().Where(d => d.guildId == guildId).FirstOrDefault();

            return guild;
        }

        public UserInformationResponse.UserGuild RequestGuild(int? guildId)
        {
            if(guildId == null)
            {
                return null;
            }

            GuildScheme? guild = collection.AsQueryable().Where(d => d.guildId == guildId).FirstOrDefault();

            if (guild == null)
            {
                return null;
            }

            UserInformationResponse.UserGuild userGuild = new()
            {
                skillDada = guild.skillDada,
                state = guild.state,
                aPoint = guild.aPoint,
                closeTime = guild.closeTime,
                count = guild.count,
                createTime = guild.createTime,
                emblem = guild.emblem,
                guildType = guild.guildType,
                idx = guild.guildId,
                level = guild.level,
                limitLevel = guild.limitlevel,
                maxCount = guild.maxCount,
                memberGrade = guild.memberGrade,
                name = guild.name,
                notice = guild.notice,
                occupy = guild.occupy,
                point = guild.point,
                world = guild.world,
            };

            return userGuild;
        }
        public List<GuildMember.MemberData> RequestGuildMembers(int? guildId)
        {
            if (guildId == null)
            {
                return null;
            }

            GuildScheme? guild = collection.AsQueryable().Where(d => d.guildId == guildId).FirstOrDefault();

            if (guild == null)
            {
                return null;
            }

            return guild.memberData;
        }


        public List<RoGuild> GetAllGuilds(string session)
        {
            var allGuilds = collection.AsQueryable().ToList();

            List<RoGuild> returnGuilds = new();

            if(allGuilds == null)
            {
                return null;
            }

            foreach (var guild in allGuilds)
            {
                RoGuild dbGuild = new()
                {
                    apnt = guild.aPoint,
                    cnt = guild.count,
                    mxCnt = guild.maxCount,
                    gidx = guild.guildId,
                    gnm = guild.name,
                    gtyp = guild.guildType,
                    emb = guild.emblem,
                    lev = guild.level,
                    ntc = guild.notice,
                    world = guild.world,
                    list = DatabaseManager.GuildApplication.RetrieveGuildApplication(session, guild.guildId),
                };

                returnGuilds.Add(dbGuild);
            }

            return returnGuilds;
        }


    }

}
