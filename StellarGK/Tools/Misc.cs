
namespace StellarGK.Tools
{
    public static class Misc
    {
        public static bool NameCheck(string username)
        {
            string[] BadWords = Constants.Badwords;

            bool isBadWord = false;
            var name = username.ToLower();
            isBadWord = BadWords.Any(badWord => name.Contains(badWord));
            if (isBadWord)
            {
                return true;
            }
            return false;
        }

    }
}
