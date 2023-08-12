using System.Text.Json;
using System.Text.Json.Nodes;
using static StellarGK.Tools.Compression;
using static StellarGK.Tools.Crypto;

namespace StellarGK.Host
{
    public partial class PacketHandler
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new();
        public static async Task<string> ProcessRequest(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.Request.Headers.UserAgent.Contains("BestHTTP"))
            {
                var rawRequest = await Stream2ByteArray(context.Request.Body);

                var decompressedRequest = Decompress(rawRequest);

                var keyIndex = Decrypt(decompressedRequest, out var decryptedRequest);

                var node = JsonSerializer.Deserialize<JsonNode>(decryptedRequest, JsonSerializerOptions);

                if (node is null)
                {
                    return "{}";
                }

                object response;

                if (node is JsonArray array)
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

                var serialized = JsonSerializer.Serialize(response, JsonSerializerOptions);

                var encrypted = Encrypt(serialized, keyIndex);

                return encrypted;
            }

            return "shouldnt happen";
        }
        private static object ProcessPacket(JsonNode raw, IServiceProvider serviceProvider)
        {
            var rawPacket = raw.Deserialize<RawPacket>();

            if (!CommandsMapper.TryGetValue(rawPacket.Method, out var endpointMapping))
            {
                throw new Exception("Unsupported Packet");
            }

            var result = endpointMapping(rawPacket, serviceProvider);

            return result;
        }
        internal static object CommandMapping<TEndpoint, TParams>(RawPacket rawPacket, IServiceProvider serviceProvider) where TEndpoint : BaseCommandHandler<TParams>
        {
            var @params = rawPacket.Params.Deserialize<TParams>();

            var commandHandler = ActivatorUtilities.CreateInstance<TEndpoint>(serviceProvider);

            commandHandler.BasePacket = rawPacket;

            return commandHandler.Handle(@params);
        }
        public static List<string> CommandsMapped => CommandsMapper.Keys.Select(commandId =>
        {
            var commandIdStr = commandId.ToString();
            var enumText = ((CommandId)commandId).ToString();

            if (commandIdStr == enumText)
            {
                enumText = "??????";
            }

            return $"{commandId} {enumText}";
        }).ToList();
    }
}
