using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGKLibrary.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGuild : DatabaseTable<GuildScheme>
    {
        public DatabaseGuild() : base("Guilds")
        {
        }

        public void Create()
        {
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

        public List<RoGuild> GetAllGuilds(string session)
        {
            var allGuilds = Collection.AsQueryable().ToList();

            List<RoGuild> returnGuilds = new();

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