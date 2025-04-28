using CommanderCS.Library.Shared.Protocols;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a guild.
    /// </summary>
    public class GuildScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the guild ID.
        /// </summary>
        public int GuildId { get; set; }

        /// <summary>
        /// Gets or sets the name of the guild.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the level of the guild.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the point of the guild.
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// Gets or sets the alliance point of the guild.
        /// </summary>
        public int AlliancePoint { get; set; }

        /// <summary>
        /// Gets or sets the emblem of the guild.
        /// </summary>
        public int Emblem { get; set; }

        /// <summary>
        /// Gets or sets the type of the guild.
        /// </summary>
        public int GuildType { get; set; }

        /// <summary>
        /// Gets or sets the limit level of the guild.
        /// </summary>
        public int LimitLevel { get; set; }

        /// <summary>
        /// Gets or sets the notice of the guild.
        /// </summary>
        public string Notice { get; set; }

        /// <summary>
        /// Gets or sets the state of the guild.
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// Gets or sets the close time of the guild.
        /// </summary>
        public double CloseTime { get; set; }

        /// <summary>
        /// Gets or sets the create time of the guild.
        /// </summary>
        public double CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the maximum count of the guild.
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// Gets or sets the count of the guild.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the skill data of the guild.
        /// </summary>
        public List<UserInformationResponse.UserGuild.GuildSkill> SkillDada { get; set; }

        /// <summary>
        /// Gets or sets the member data of the guild.
        /// </summary>
        public List<MemberData> MemberData { get; set; }

        /// <summary>
        /// Gets or sets the occupy value of the guild.
        /// </summary>
        public int Occupy { get; set; }

        /// <summary>
        /// Gets or sets the world of the guild.
        /// </summary>
        public int World { get; set; }

        /// <summary>
        /// Gets or sets the board list data of the guild.
        /// </summary>
        public List<GuildBoardData> BoardListData { get; set; }

        /// <summary>
        /// Gets or sets the last edit time of the guild.
        /// </summary>
        public double? LastEdit { get; set; }
    }

    /// <summary>
    /// Represents the member data.
    /// </summary>
    public class MemberData
    {
        /// <summary>
        /// Gets or sets the unique number identifier.
        /// </summary>
        [JsonProperty("uno")]
        public int Uno { get; set; }

        /// <summary>
        /// Gets or sets the name of the member.
        /// </summary>
        [JsonProperty("unm")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail ID.
        /// </summary>
        [JsonProperty("thumb")]
        public int Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the level of the member.
        /// </summary>
        [JsonProperty("lv")]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the last time the member was active.
        /// </summary>
        [JsonProperty("time")]
        public double LastTime { get; set; }

        /// <summary>
        /// Gets or sets the join date of the member.
        /// </summary>
        [JsonProperty("jdate")]
        public double JoinDate { get; set; }

        /// <summary>
        /// Gets or sets the grade of the member.
        /// </summary>
        [JsonProperty("mstr")]
        public int MemberGrade { get; set; }

        /// <summary>
        /// Gets or sets the today's point of the member.
        /// </summary>
        [JsonProperty("dpnt")]
        public int TodayPoint { get; set; }

        /// <summary>
        /// Gets or sets the total point of the member.
        /// </summary>
        [JsonProperty("mpnt")]
        public int TotalPoint { get; set; }

        /// <summary>
        /// Gets or sets the payment bonus point of the member.
        /// </summary>
        [JsonProperty("pbpnt")]
        public int PaymentBonusPoint { get; set; }

        /// <summary>
        /// Gets or sets the world of the member.
        /// </summary>
        [JsonProperty("world")]
        public int World { get; set; }
    }
}