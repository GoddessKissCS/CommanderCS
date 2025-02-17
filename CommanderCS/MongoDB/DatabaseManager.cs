﻿using CommanderCS.MongoDB.Handlers;
using CommanderCSLibrary.Cryptography;
using CommanderCSLibrary.Shared;

namespace CommanderCS.MongoDB
{
    /// <summary>
    /// Manages the database interactions for various entities.
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// Gets the database manager for auto-increments.
        /// </summary>
        public static DatabaseAutoIncrements AutoIncrements { get; } = new();

        /// <summary>
        /// Gets the database manager for user accounts.
        /// </summary>
        public static DatabaseAccount Account { get; } = new();

        /// <summary>
        /// Gets the database manager for dormitory data.
        /// </summary>
        public static DatabaseDormitory Dormitory { get; } = new();

        /// <summary>
        /// Gets the database manager for device codes.
        /// </summary>
        public static DatabaseDeviceCode DeviceCode { get; } = new();

        /// <summary>
        /// Gets the database manager for servers.
        /// </summary>
        public static DatabaseRegion Region { get; } = new();

        /// <summary>
        /// Gets the database manager for guilds.
        /// </summary>
        public static DatabaseGuild Guild { get; } = new();

        /// <summary>
        /// Gets the database manager for guild applications.
        /// </summary>
        public static DatabaseGuildApplication GuildApplication { get; } = new();

        /// <summary>
        /// Gets the database manager for game version information.
        /// </summary>
        public static DatabaseGameVersion GameVersionInfo { get; } = new();

        /// <summary>
        /// Gets the database manager for game table version.
        /// </summary>
        public static DatabaseGameTableVersion GameTableVersion { get; } = new();

        /// <summary>
        /// Gets the database manager for game profiles.
        /// </summary>
        public static DatabaseGameProfile GameProfile { get; } = new();

        /// <summary>
        /// Gets the database manager for common notices.
        /// </summary>
        public static DatabaseCommonNotice CommonNotice { get; } = new();

        /// <summary>
        /// Gets the database manager for event notices.
        /// </summary>
        public static DatabaseEventNotice EventNotice { get; } = new();

        /// <summary>
        /// Gets the database manager for banner rotation.
        /// </summary>
        public static DatabaseRotationBanner RotationBanner { get; } = new();

        /// <summary>
        /// Initializes the database manager.
        /// </summary>
        public static void Init()
        {
            // Check if the game table version matches the current version

            var gametables = GameTableVersion.Get();

            if (gametables is not null)
            {
                if (gametables.Version == 20220312000000)
                {
                    return;
                }
            }

            string ip = Misc.GetLocalIPAddress();

            string cdn_url = Crypto.Base64Encode("http://" + ip + ":5000/FileCDN/");
            string game_url = Crypto.Base64Encode("http://" + ip + ":5000/checkData.php");
            string chat_url = Crypto.Base64Encode("http://" + ip + ":5000/chat.php");

            // Initialize game version information
            GameVersionInfo.Insert(1, "1.066.12", cdn_url, game_url, chat_url, false, false, false, false);
            GameVersionInfo.Insert(2, "1.066.12", cdn_url, game_url, chat_url, false, false, false, false);

            // Initialize game table version
            GameTableVersion.Insert(20220312000000);

            // Initialize Regions
            Region.Insert(1, "Korea", 140, "18-20", 1643673600, 0, 0);
            Region.Insert(2, "Global", 140, "18-20", 1643673600, 0, 0);

            // Initialize Server

            // initalize some banners
            RotationBanner.Insert("1720097316", "1722170916", 0, 0, "http://" + ip + ":5000/FileCDN/Event/TitleBanner/Notice_Icon.png", "", CommanderCSLibrary.Shared.Enum.BannerListType.None);
            RotationBanner.Insert("1720097316", "1722170916", 1, 1, "http://" + ip + ":5000/FileCDN/Event/TitleBanner/Event_Icon.png", "", CommanderCSLibrary.Shared.Enum.BannerListType.None);
        }
    }
}