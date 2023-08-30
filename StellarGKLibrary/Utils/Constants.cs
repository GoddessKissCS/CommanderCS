using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace StellarGKLibrary.Utils
{

    public static partial class Constants
    {
        public static string[] Badwords =
        {
        "/",
        ".",
        "="
        };

        public static int CurrentTimeStamp
        {
            get
            {
                DateTime unixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan timeSinceEpoch = DateTime.UtcNow - unixEpoch;
                int unixTimestamp = (int)timeSinceEpoch.TotalSeconds;

                return unixTimestamp;
            }
        }
        public static class CommandIdsForChatting
        {
            public const string CheckChattingMsg = "checkMsg";
            public const string SendChatMsgChatting = "sendMsg";
            public const string SendGuildMsgChatting = "sendGuildMsg";
            public const string SendwaitChannelMsg = "waitChannel";
            public const string SendWaitChatMsg = "waitChat";
            public const string SendwaitGuildMsg = "waitGuild";
            public const string SendWhisperMsgChatting = "sendWhisperMsg";
        }

        public static string CreateGuestName
        {
            get
            {
                const string characters = "0123456789";
                const int nameLength = 8;

                StringBuilder nameBuilder = new(nameLength);

                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    byte[] data = new byte[nameLength];
                    rng.GetBytes(data);

                    for (int i = 0; i < data.Length; i++)
                    {
                        byte value = data[i];
                        char character = characters[value % characters.Length];
                        nameBuilder.Append(character);
                    }
                }

                string name = "Guest" + nameBuilder.ToString();
                return name;
            }
        }

        public static string ChangeDeviceCode
        {
            get
            {
                const string characters = "aAbBcCdDeEfFgGhHjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ123456789";
                const int codeLength = 16;

                StringBuilder codeBuilder = new(codeLength);

                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    byte[] data = new byte[codeLength];
                    rng.GetBytes(data);

                    for (int i = 0; i < data.Length; i++)
                    {
                        byte value = data[i];
                        char character = characters[value % characters.Length];
                        codeBuilder.Append(character);
                    }
                }

                string code = codeBuilder.ToString();
                return code;
            }
        }

        public static IPAddress GetLocalIP
        {
            get
            {
                IPAddress localIP = IPAddress.None;

                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                        (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                         networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                    {
                        IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                        foreach (UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                        {
                            if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                localIP = ipInfo.Address;
                                break;
                            }
                        }
                    }

                    if (!IPAddress.None.Equals(localIP))
                        break;
                }

                if (IPAddress.None.Equals(localIP))
                    localIP = IPAddress.Loopback;

                return localIP;
            }
        }
    }
}