namespace StellarGKLibrary.Utils
{
    public static class Misc
    {
        public static string[] Badwords = {
            "/", ".", "="
        };

        public static bool NameCheck(string username)
        {
            var name = username.ToLower();
            bool isBadWord = Badwords.Any(name.Contains);
            return isBadWord;
        }
    }
}