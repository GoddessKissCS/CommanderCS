using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Models
{
    public class AccountScheme
    {
        public int Id { get; set; }
        public string token { get; set; }
        public long lastLoginTime { get; set; }
        public long creationTime { get; set; }
        public int worldState { get; set; }
        public int server { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int platformId { get; set; }
        public string device { get; set; }
        public string deviceid { get; set; }
        public int patchType { get; set; }
        public int osCode { get; set; }
        public string osversion { get; set; }
        public string gameversion { get; set; }
        public string apk { get; set; }
        public string pushRegistrationId { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string gpid { get; set; }
        public int channel { get; set; }
        public bool skip { get; set; }
        public int step { get; set; }
        public string session { get; set; }
        public string uno { get; set; }
        public int lastStage { get; set; }
        public bool isBanned { get; set; }
        public string banReason { get; set; }

        // TODO REMOVING THIS
        // I OPT FOR CONSOLE COMMANDS RATHER
        public int PermissionLevel { get; set; }
        public int? guildId { get; set; }
        public bool notifaction { get; set; }
        public List<BlockUser> blockedUsers { get; set; }
        public int resetDateTime { get; set; }

    }
}
