using System.Buffers;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace StellarGK.Utils
{
    internal class Crypto
    {
        static Crypto()
        {
            var key = "Zb*!W-$&TA6mrIEU-F=ShH7=($ucOZdg";
            _key = _encoding.GetBytes(key);
        }

        private static readonly byte[] _key;
        private static readonly Encoding _encoding = Encoding.UTF8;

        public static string Encrypt(string input) => Encrypt(_encoding.GetBytes(input));
        public static string Encrypt(byte[] input)
        {
            var engine = new RijndaelEngine(256);
            var padding = new ZeroBytePadding();
            var cipher = new PaddedBufferedBlockCipher(engine, padding);
            var parameters = new KeyParameter(_key);
            cipher.Init(true, parameters);
            var comparisonBytes = new byte[cipher.GetOutputSize(input.Length)];
            var length = cipher.ProcessBytes(input, comparisonBytes, 0);

            cipher.DoFinal(comparisonBytes, length);

            return Convert.ToBase64String(comparisonBytes);
        }
        public static string Decrypt(string input) => Decrypt(Convert.FromBase64String(input));

        public static string Decrypt(byte[] input)
        {
            var engine = new RijndaelEngine(256);
            var padding = new ZeroBytePadding();
            var cipher = new PaddedBufferedBlockCipher(engine, padding);
            var parameters = new KeyParameter(_key);
            cipher.Init(false, parameters);

            var comparisonBytes = new byte[cipher.GetOutputSize(input.Length)];
            var length = cipher.ProcessBytes(input, comparisonBytes, 0);

            cipher.DoFinal(comparisonBytes, length);

            var nullIndex = comparisonBytes.Length - 1;
            while (comparisonBytes[nullIndex] == 0)
                nullIndex--;
            comparisonBytes = comparisonBytes.Take(nullIndex + 1).ToArray();

            var result = _encoding.GetString(comparisonBytes, 0, comparisonBytes.Length);

            return result;
        }
        public static string ComputeSha256Hash(string input) => ComputeSha256Hash(_encoding.GetBytes(input));
        public static string ComputeSha256Hash(byte[] input)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(input);
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
