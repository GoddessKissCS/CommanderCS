using CommanderCS.Library.Enums;
using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents the account information stored in the database.
    /// </summary>
    public class AccountScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the account.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the member ID of the account.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the account.
        /// </summary>
        public string Password_Hash { get; set; }

        /// <summary>
        /// Gets or sets the authentication token of the account.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the last login time.
        /// </summary>
        public long LastLoginTime { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the account creation time.
        /// </summary>
        public long CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the channel of the account.
        /// </summary>
        public int Channel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is banned.
        /// </summary>
        public bool? isBanned { get; set; }

        /// <summary>
        /// Gets or sets the reason for banning the account.
        /// </summary>
        public string? BanReason { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the clearance level of the account.
        /// </summary>
        public Clearance Clearance { get; set; }

        /// <summary>
        /// Gets or sets the ID of the last server logged in by the account.
        /// </summary>
        public int LastServerLoggedIn { get; set; }

        /// <summary>
        /// Gets or sets the platform associated with the account.
        /// </summary>
        public Platform Platform { get; set; }
    }

    /// <summary>
    /// Represents the clearance levels for accounts.
    /// </summary>
    public enum Clearance
    {
        Guest,
        Player,
        Moderator,
        Administrator,
        Owner,
    }
}