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
    }
}
