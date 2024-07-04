
using CommanderCSLibrary.Shared.Protocols;
using Org.BouncyCastle.Asn1.X509;
using System.Diagnostics;
using System.Reflection;

namespace CommanderCSLibrary.Shared
{
    public static class Misc
    {
        public static string[] Badwords =
        {
            "/", ".", "=", "Mod", "Admin", "Owner", "_", "?", "&", "$", "!",
        };


        public static List<string> BannedWords {  get; set; }


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
    }
}