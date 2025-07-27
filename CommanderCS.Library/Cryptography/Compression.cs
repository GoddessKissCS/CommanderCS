using Tival.GZipCompressor;

namespace CommanderCS.Library.Cryptography
{
    public class Compression
    {
        public static string Decompress(byte[] Input)
        {
            GZipCompressor GZIP = new();
            return GZIP.Decompress(Input);
        }

        public static async Task<byte[]> Stream2ByteArray(Stream instream)
        {
            if (instream is MemoryStream stream)
                return stream.ToArray();

            var memoryStream = new MemoryStream();
            await instream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}