using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using static CommanderCS.Protocols.UserInformationResponse;

namespace CommanderCS.Utils
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

    }
}