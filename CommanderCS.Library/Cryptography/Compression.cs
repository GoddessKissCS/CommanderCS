using System.IO.Compression;
using System.Text;


namespace CommanderCS.Library.Cryptography
{
    public class Compression
    {

        public static string DecompressGZipToString(byte[] compressedData)
        {
            if (compressedData == null || compressedData.Length == 0)
                return string.Empty;

            Encoding encoding = Encoding.UTF8;

            try
            {
                using (var compressedStream = new MemoryStream(compressedData))
                using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                using (var reader = new StreamReader(gzipStream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (InvalidDataException)
            {
                // Handle cases where data is not valid GZip
                return encoding.GetString(compressedData); // Return as if not compressed
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new InvalidOperationException("Failed to decompress GZip data", ex);
            }
        }

        // TIVAL.GZIP
        // just in case

        //public static string Decompress(byte[] Input)
        //{
        //    GZipCompressor GZIP = new();
        //    return GZIP.Decompress(Input);
        //}

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