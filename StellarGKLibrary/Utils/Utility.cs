using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using static StellarGKLibrary.Protocols.UserInformationResponse;

namespace StellarGKLibrary.Utils
{
    public class Utility
    {
        public static DateTime ConvertToDateTime(string yyyymmdd)
        {
            if (string.IsNullOrEmpty(yyyymmdd) || yyyymmdd.Length != 8)
            {
                return default(DateTime);
            }
            string year = yyyymmdd.Substring(0, 4);
            string month = yyyymmdd.Substring(4, 2);
            string day = yyyymmdd.Substring(6, 2);
            int num, num2, num3;
            if (!int.TryParse(year, out num))
            {
                return default(DateTime);
            }
            if (!int.TryParse(month, out num2))
            {
                return default(DateTime);
            }
            if (!int.TryParse(day, out num3))
            {
                return default(DateTime);
            }
            return new DateTime(num, num2, num3);
        }

        public static int CurrentTimeStamp()
        {
            DateTime unixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSinceEpoch = DateTime.UtcNow - unixEpoch;
            int unixTimestamp = (int)timeSinceEpoch.TotalSeconds;
            return unixTimestamp;
        }

        public static double GetCurrentTimeInSeconds()
        {
            DateTime unixEpoch = new(1970, 1, 1, 0, 0, 0);
            TimeSpan timeSpan = DateTime.UtcNow - unixEpoch;
            return timeSpan.TotalSeconds;
        }

        public static double CurrentTimeInMilliseconds()
        {
            TimeSpan span = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
            return span.TotalMilliseconds;
        }

        public static string CreateGuestName()
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

        public static string ChangeDeviceCode()
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

        public static IPAddress GetLocalIP()
        {
            IPAddress localIP = IPAddress.None;

            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    (networkInterface.NetworkInterfaceType ==
                         NetworkInterfaceType.Wireless80211 ||
                     networkInterface.NetworkInterfaceType ==
                         NetworkInterfaceType.Ethernet))
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                    foreach (
                        UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                    {
                        if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            localIP = ipInfo.Address;
                            break;
                        }
                    }
                }

                if (!IPAddress.None.Equals(localIP)) break;
            }

            if (IPAddress.None.Equals(localIP)) localIP = IPAddress.Loopback;

            return localIP;
        }



    }
}