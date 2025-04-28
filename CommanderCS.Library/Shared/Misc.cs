using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace CommanderCS.Library.Shared
{
    public static class Misc
    {
        public static string[] Badwords =
        {
            "/", ".", "=", "Mod", "Admin", "Owner", "_", "?", "&", "$", "!",
        };

        public static List<string> BannedWords { get; set; }

        public static bool NameCheck(string username)
        {
            var name = username.ToLower();
            bool isBadWord = Badwords.Any(name.Contains);
            return isBadWord;
        }

        public static List<string> GetBadWords()
        {
            string filter = "*.txt";

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string[] files = Directory.GetFiles(path, filter);

            List<string> linesList = [];

            foreach (var file in files)
            {
                foreach (string line in File.ReadLines(file))
                {
                    // Split the line at the '#' character
                    string[] parts = line.Split('#');

                    // Add the part before the '#' character to the list
                    if (parts.Length > 0)
                    {
                        linesList.Add(parts[0].Trim());
                    }
                }
            }
            return linesList;
        }

        public static string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return localIP = endPoint.Address.ToString();
            }
        }
    }
}