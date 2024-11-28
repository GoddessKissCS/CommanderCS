using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents the guild application scheme.
    /// </summary>
    public class GuildApplicationScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the guild application.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the guild.
        /// </summary>
        public int GuildId { get; set; }

        /// <summary>
        /// Gets or sets the unique number identifier.
        /// </summary>
        public int Uno { get; set; }

        /// <summary>
        /// Gets or sets the data of the member applying to join the guild.
        /// </summary>
        public GuildMember.MemberData JoinMemberData { get; set; }

        /// <summary>
        /// Gets or sets the time when the application was made.
        /// </summary>
        public double ApplyTime { get; set; }
    }
}