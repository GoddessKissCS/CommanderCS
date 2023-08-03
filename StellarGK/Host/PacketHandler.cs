using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using MongoDB.Bson;
using static StellarGK.Utils.Compression;
using static StellarGK.Utils.Crypto;

namespace StellarGK.Host
{
    public partial class PacketHandler
    {

        public static JsonSerializerOptions options = new()
        {

        };

        public static string ProcessRequest(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.Request.Method == "POST" || context.Request.Headers.UserAgent.Contains("BestHTTP"))
            {
                JsonNode node = Decrypt(Decompress(Stream2ByteArray(context.Request.Body)));

                if (node is null)
                {
                    return "{}";
                    //throw new ArgumentNullException(nameof(node));
                }

                if (node is JsonArray array)
                {
                    // This only gets executed if it recived an array

                    var responses = new List<object>();

                    foreach (var item in array)
                    {
                        if (item is null)
                        {
                            continue;
                        }

                        var response = ProcessPacket(item, serviceProvider);

                        responses.Add(response);
                    }

                    // Array Here

                    return Encrypt(JsonSerializer.Serialize(responses, options));

                }

                var packet = ProcessPacket(node, serviceProvider);

                return Encrypt(JsonSerializer.Serialize(packet, options));
            }
            return "shouldnt happend";
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
