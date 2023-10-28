using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static StellarGKLibrary.Cryptography.Compression;
using static StellarGKLibrary.Cryptography.Crypto;

namespace StellarGK.Host
{
    public partial class PacketHandler
    {
        public static async Task<string> ProcessRequest(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.Request.Headers.UserAgent.Contains("BestHTTP"))
            {
                var rawRequest = await Stream2ByteArray(context.Request.Body);

                var decompressedRequest = Decompress(rawRequest);

                var keyIndex = Decrypt(decompressedRequest, out var decryptedRequest);

                var node = JsonConvert.DeserializeObject<JToken>(decryptedRequest);

                if (node is null)
                {
                    return "{}";
                }

                object response;

                if (node is JArray array)
                {
                    var responses = new List<object>();

                    foreach (var item in array)
                    {
                        if (item is null)
                        {
                            continue;
                        }

                        var partialResponse = ProcessPacket(item, serviceProvider);

                        responses.Add(partialResponse);
                    }

                    response = responses;
                }
                else
                {
                    response = ProcessPacket(node, serviceProvider);
                }

                if (response == "{}")
                {
                    return Encrypt("{}", keyIndex);
                }

                var serialized = JsonConvert.SerializeObject(response);

                var encrypted = Encrypt(serialized, keyIndex);

                return encrypted;
            }

            return "shouldnt happen";
        }

        private static object ProcessPacket(JToken raw, IServiceProvider serviceProvider)
        {
            var paramsPacket = raw.ToObject<ParamsPacket>();

            if (!CommandsMapper.TryGetValue(paramsPacket.Method, out var endpointMapping))
            {
                throw new Exception("Unsupported Packet");
            }

            var result = endpointMapping(paramsPacket, serviceProvider);

            return result;
        }

        internal static object CommandMapping<TEndpoint, TParams>(ParamsPacket paramsPacket, IServiceProvider serviceProvider) where TEndpoint : BaseMethodHandler<TParams>
        {
            var @params = paramsPacket.Params.ToObject<TParams>();

            var commandHandler = ActivatorUtilities.CreateInstance<TEndpoint>(serviceProvider);

            commandHandler.BasePacket = paramsPacket;

            return commandHandler.Handle(@params);
        }

        public static List<string> CommandsMapped => CommandsMapper.Keys.Select(commandId =>
        {
            var commandIdStr = commandId.ToString();
            var enumText = ((Method)commandId).ToString();

            if (commandIdStr == enumText)
            {
                enumText = "??????";
            }

            return $"{commandId} {enumText}";
        }).ToList();
    }
}