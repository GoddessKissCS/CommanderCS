using MongoDB.Bson;
using StellarGKLibrary.Enum;

namespace StellarGK.Database.Schemes
{
    public class AccountScheme
    {
        public ObjectId Id { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Password_Hash { get; set; }
        public string Token { get; set; }
        public long LastLoginTime { get; set; }
        public long CreationTime { get; set; }
        public int Channel { get; set; }
        public bool? isBanned { get; set; }
        public string? BanReason { get; set; }
        public Clearance Clearance { get; set; }
        public int LastServerLoggedIn { get; set; }
        public Platform Platform { get; set; }
    }

    public enum Clearance : int
    {
        Guest = 0,
        Player = 1,
        Moderator = 2,
        Administrator = 3,
        Owner = 4,
    }

}
