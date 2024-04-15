using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents the game version scheme.
    /// </summary>
    public class GameVersionScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the game version.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the channel ID.
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// Gets or sets the version of the game.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the state of the version.
        /// </summary>
        public bool Version_State { get; set; }

        /// <summary>
        /// Gets or sets the URL for the CDN.
        /// </summary>
        public string Cdn_Url { get; set; }

        /// <summary>
        /// Gets or sets the URL for the game.
        /// </summary>
        public string Game_Url { get; set; }

        /// <summary>
        /// Gets or sets the URL for the chat.
        /// </summary>
        public string Chat_Url { get; set; }

        /// <summary>
        /// Gets or sets whether to show the policy.
        /// </summary>
        public bool showPolicy { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of words.
        /// </summary>
        public Dictionary<string, double> Word { get; set; }

        /// <summary>
        /// Gets or sets whether to perform file check.
        /// </summary>
        public bool fileCheck { get; set; }

        /// <summary>
        /// Gets or sets whether Google login is enabled.
        /// </summary>
        public bool enableGoogleLogin { get; set; }
    }
}