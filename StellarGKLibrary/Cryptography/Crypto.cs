using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;
using System.Text;

namespace StellarGKLibrary.Cryptography
{
    public class Crypto
    {
        private static readonly byte[][] _keys;
        private static readonly Encoding _encoding = Encoding.UTF8;
        static Crypto()
        {
            _keys = new byte[][]
            {
                 _encoding.GetBytes("Zb*!W-$&TA6mrIEU-F=ShH7=($ucOZdg"),
                 _encoding.GetBytes("IU is Korea Best Singer! really!"),
            };

        }

        public static int Decrypt(string input, out string value) => Decrypt(Convert.FromBase64String(input), out value);

        public static int Decrypt(byte[] input, out string value)
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                var data = DecryptInternal(input, _keys[i]);

                var valid = false;

                valid = valid || data.StartsWith('{') && data.EndsWith('}');

                valid = valid || data.StartsWith('[') && data.EndsWith(']');

                if (!valid)
                {
                    continue;
                }

                value = data;

                return i;
            }

            throw new Exception("No Valid Key Was Found");
        }

        private static PaddedBufferedBlockCipher InitializeCipher(byte[] key, bool forEncryption)
        {
            var engine = new RijndaelEngine(256);
            var padding = new ZeroBytePadding();
            var parameters = new KeyParameter(key);

            var cipher = new PaddedBufferedBlockCipher(engine, padding);
            cipher.Init(forEncryption, parameters);

            return cipher;
        }

        private static string DecryptInternal(byte[] input, byte[] key)
        {
            var cipher = InitializeCipher(key, false);

            var outputSize = cipher.GetOutputSize(input.Length);

            var output = new byte[outputSize];

            var length = cipher.ProcessBytes(input, output, 0);

            var final = cipher.DoFinal(output, length);

            var totalLength = length + final;

            var decodedBytes = output[0..totalLength];

            var result = _encoding.GetString(decodedBytes);

            return result;
        }

        public static string Encrypt(string input, int keyIndex) => Encrypt(_encoding.GetBytes(input), keyIndex);
        public static string Encrypt(byte[] input, int keyIndex)
        {
            var cipher = InitializeCipher(_keys[keyIndex], true);

            var comparisonBytes = new byte[cipher.GetOutputSize(input.Length)];
            var length = cipher.ProcessBytes(input, comparisonBytes, 0);

            cipher.DoFinal(comparisonBytes, length);

            return Convert.ToBase64String(comparisonBytes);
        }

        public static string ComputeSha256Hash(string input) => ComputeSha256Hash(_encoding.GetBytes(input));
        public static string ComputeSha256Hash(byte[] input)
        {
            var hash = SHA256.HashData(input);

            StringBuilder builder = new();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
