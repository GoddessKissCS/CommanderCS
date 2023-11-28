using MongoDB.Bson;
using CommanderCS.Protocols;

namespace CommanderCS.Database.Schemes
{
    public class GuildApplicationScheme
    {
        public ObjectId Id { get; set; }
        public int GuildId { get; set; }
        public int Uno { get; set; }
        public GuildMember.MemberData JoinMemberData { get; set; }
        public double ApplyTime { get; set; }
    }
}