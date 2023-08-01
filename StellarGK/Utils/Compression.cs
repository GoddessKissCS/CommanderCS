using System.Text;
using Tival.GZipCompressor;

namespace StellarGK.Utils
{
    internal class Compression
    {
        public static string Decompress(byte[] Input)
        {
            GZipCompressor GZIP = new();
            return GZIP.Decompress(Input);
        }

        public static byte[] Stream2ByteArray(Stream instream)
        {
            if (instream is MemoryStream stream)
                return stream.ToArray();

            var memoryStream = new MemoryStream();
            instream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public static string ByteArray2String(byte[] Input)
        {
            return Encoding.UTF8.GetString(Input);
        }
    }
}
