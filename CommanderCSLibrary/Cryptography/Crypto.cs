using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;
using System.Text;

namespace CommanderCSLibrary.Cryptography
{
    public class Crypto
    {
        private static readonly byte[][] _keys;
        private static readonly Encoding _encoding = Encoding.UTF8;

        static Crypto()
        {
            _keys =
            [
                _encoding.GetBytes("Zb*!W-$&TA6mrIEU-F=ShH7=($ucOZdg"),
                _encoding.GetBytes("IU is Korea Best Singer! really!"),
                _encoding.GetBytes("JSON134c4dabedcd462bad9d775873de")
            ];
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

            var base64string = Convert.ToBase64String(comparisonBytes);

            return base64string;
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
            var computedHash = builder.ToString();  
            return computedHash;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var encodedPlainText = Convert.ToBase64String(plainTextBytes);
            return encodedPlainText;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            var decodedPlainText = Encoding.UTF8.GetString(base64EncodedBytes);
            return decodedPlainText;
        }

    }

}