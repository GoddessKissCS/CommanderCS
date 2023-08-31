using Newtonsoft.Json;
using StellarGKLibrary.Cryptography;
using StellarGKLibrary.Shared.Regulation;
using System.Runtime.InteropServices;

namespace StellarGKLibrary.Utils
{
    public class Utility
    {
        public static DateTime ConvertToDateTime(string yyyymmddFormatString)
        {
            if (string.IsNullOrEmpty(yyyymmddFormatString) || yyyymmddFormatString.Length != 8)
            {
                return default(DateTime);
            }
            string text = yyyymmddFormatString.Substring(0, 4);
            string text2 = yyyymmddFormatString.Substring(4, 2);
            string text3 = yyyymmddFormatString.Substring(6, 2);
            int num = 0;
            if (!int.TryParse(text, out num))
            {
                return default(DateTime);
            }
            int num2 = 0;
            if (!int.TryParse(text2, out num2))
            {
                return default(DateTime);
            }
            int num3 = 0;
            if (!int.TryParse(text3, out num3))
            {
                return default(DateTime);
            }
            return new DateTime(num, num2, num3);
        }
    }
}
