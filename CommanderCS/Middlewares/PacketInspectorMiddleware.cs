using CommanderCSLibrary.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGK.Middlewares
{
    public class PacketInspectorMiddleware : Controller
    {
        private readonly ILogger<PacketInspectorMiddleware> Logger;
        private readonly RequestDelegate Pipeline;

        public PacketInspectorMiddleware(RequestDelegate Pipeline, ILogger<PacketInspectorMiddleware> Logger)
        {
            this.Logger = Logger;
            this.Pipeline = Pipeline;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Before Execution
                await Pipeline(context).ConfigureAwait(false);
                // After Execution

                var rawRequest = await Compression.Stream2ByteArray(context.Request.Body);

                var decompressedRequest = Compression.Decompress(rawRequest);

                var keyIndex = Crypto.Decrypt(decompressedRequest, out var decryptedRequest);

                var node = JsonConvert.DeserializeObject<JToken>(decryptedRequest);

                Console.WriteLine("Request: " + node.ToString());
            }
            catch (BadHttpRequestException _)
            {
                // Ignore those exceptions since they are created by connection errors and not our code
            }
            catch (Exception ex)
            {
                Logger.LogError(exception: ex, $"Uncaught Exception. Message => \"{ex.Message}\"");
                throw;
            }
        }
    }
}