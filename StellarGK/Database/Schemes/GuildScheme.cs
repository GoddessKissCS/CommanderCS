using MongoDB.Bson;
using StellarGKLibrary.Protocols;

namespace StellarGK.Database.Schemes
{
    public class GuildScheme
    {
        public ObjectId Id { get; set; }
        public int GuildId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Point { get; set; }
        public int aPoint { get; set; }
        public int MemberGrade { get; set; }
        public int Emblem { get; set; }
        public int GuildType { get; set; }
        public int Limitlevel { get; set; }
        public string Notice { get; set; }
        public int State { get; set; }
        public double CloseTime { get; set; }
        public double CreateTime { get; set; }
        public int MaxCount { get; set; }
        public int Count { get; set; }
        public List<UserInformationResponse.UserGuild.GuildSkill> SkillDada { get; set; }
        public List<GuildMember.MemberData> MemberData { get; set; }
        public int Occupy { get; set; }
        public int World { get; set; }
        public List<GuildBoardData> BoardList { get; set; }
        public double LastGuildEdit { get; set; }
    }
}