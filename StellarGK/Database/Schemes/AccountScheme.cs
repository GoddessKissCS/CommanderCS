using MongoDB.Bson;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Schemes
{
    public class AccountScheme
    {
        public ObjectId Id { get; set; }
        public int memberId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public long lastLoginTime { get; set; }
        public long creationTime { get; set; }
        public int channel { get; set; }
        public bool? isBanned { get; set; }
        public string? banReason { get; set; }
        public Clearance clearance { get; set; }
        public List<BlockUser> blockedUsers { get; set; }
        public int lastServerLoggedIn { get; set; }
    }

    public enum Clearance : int {
        Guest = 0,
        Player = 1,
        Moderator = 2,
        Administrator = 3,
        Owner = 4,
    }

}
