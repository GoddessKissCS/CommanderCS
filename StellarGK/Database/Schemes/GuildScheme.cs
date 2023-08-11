using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Schemes
{
    public class GuildScheme
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int point { get; set; }
        public int aPoint { get; set; }
        public int memberGrade { get; set; }
        public int emblem { get; set; }
        public int guildType { get; set; }
        public int limitlevel { get; set; }
        public string notice { get; set; }
        public int state { get; set; }
        public int closeTime { get; set; }
        public int createTime { get; set; }
        public int maxCount { get; set; }
        public int count { get; set; }
        public List<UserInformationResponse.UserGuild.GuildSkill> skillDada { get; set; }
        public List<GuildMember.MemberData> memberData { get; set; }
        public int occupy { get; set; }
        public int world { get; set; }

    }
}
