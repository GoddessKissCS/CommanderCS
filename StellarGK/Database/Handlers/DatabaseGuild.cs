using MongoDB.Driver;
using StellarGK.Database.Models;
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
            GuildScheme? guild = collection.AsQueryable().Where(d => d.Id == guildId).FirstOrDefault();

            return guild;
        }

        public UserInformationResponse.UserGuild RequestGuild(int? guildId)
        {
            GuildScheme? guild = collection.AsQueryable().Where(d => d.Id == guildId).FirstOrDefault();

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
                idx = guild.Id,
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


    }

}
