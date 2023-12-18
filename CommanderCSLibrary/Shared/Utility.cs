using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace CommanderCSLibrary.Shared
{
    public class Utility
    {
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

        public static DateTime ConvertToDateTime(string yyyymmddFormatString)
        {
            if (string.IsNullOrEmpty(yyyymmddFormatString) || yyyymmddFormatString.Length != 8)
            {
                return default;
            }
            string s = yyyymmddFormatString.Substring(0, 4);
            string s2 = yyyymmddFormatString.Substring(4, 2);
            string s3 = yyyymmddFormatString.Substring(6, 2);
            int result = 0;
            if (!int.TryParse(s, out result))
            {
                return default;
            }
            int result2 = 0;
            if (!int.TryParse(s2, out result2))
            {
                return default;
            }
            int result3 = 0;
            if (!int.TryParse(s3, out result3))
            {
                return default;
            }
            return new DateTime(result, result2, result3);
        }
        public static string GetStringToDay(double time)
        {
            if (time == 0.0)
            {
                return string.Empty;
            }
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(time).ToLocalTime();
            string language = Localization.language;
            StringBuilder stringBuilder = new()
            {
                Length = 0
            };
            switch (language)
            {
                case "S_Kr":
                case "S_Beon":
                case "S_Gan":
                    stringBuilder.Append(Localization.Format("5134", dateTime.Year));
                    stringBuilder.Append("/");
                    stringBuilder.Append(Localization.Format("5135", dateTime.Month));
                    stringBuilder.Append("/");
                    stringBuilder.Append(Localization.Format("5768", dateTime.Day));
                    break;
                case "S_En":
                    stringBuilder.Append(Localization.Format("5135", dateTime.Month));
                    stringBuilder.Append("/");
                    stringBuilder.Append(Localization.Format("5768", dateTime.Day));
                    stringBuilder.Append("/");
                    stringBuilder.Append(Localization.Format("5134", dateTime.Year));
                    break;
                default:
                    stringBuilder.Append(Localization.Format("5134", dateTime.Year));
                    stringBuilder.Append("/");
                    stringBuilder.Append(Localization.Format("5135", dateTime.Month));
                    stringBuilder.Append("/");
                    stringBuilder.Append(Localization.Format("5768", dateTime.Day));
                    break;
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(dateTime.Hour);
            stringBuilder.Append(":");
            stringBuilder.Append(dateTime.Minute.ToString("D2"));
            stringBuilder.Append(":");
            stringBuilder.Append(dateTime.Second.ToString("D2"));
            return stringBuilder.ToString();
        }

    }
}