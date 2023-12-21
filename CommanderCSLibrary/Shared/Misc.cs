
namespace CommanderCSLibrary.Shared
{
    public static class Misc
    {
        public static string[] Badwords =
        {
            "/", ".", "=", "Mod", "Admin", "Owner", "_", "?", "&", "$", "!",
        };

        public static bool NameCheck(string username)
        {
            var name = username.ToLower();
            bool isBadWord = Badwords.Any(name.Contains);
            return isBadWord;
        }
    }
}