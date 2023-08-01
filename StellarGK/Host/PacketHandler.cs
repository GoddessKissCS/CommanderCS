using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using static StellarGK.Utils.Compression;
using static StellarGK.Utils.Crypto;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace StellarGK.Host
{
    public partial class PacketHandler
    {
        public static string ProcessRequest(HttpListenerContext context, IServiceProvider serviceProvider)
        {
            if (context.Request.HttpMethod == "POST" || context.Request.UserAgent == "BestHTTP")
            {
                JsonNode node = Decrypt(Decompress(Stream2ByteArray(context.Request.InputStream)));

                if (node is null)
                {
                    throw new ArgumentNullException(nameof(node));
                }


                if (node is JsonArray array)
                {
                    // This only gets executed if it recived an array

                    var responses = new List<string>();

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


                    return Encrypt(JsonConvert.SerializeObject(responses));
                }

                return Encrypt(ProcessPacket(node, serviceProvider));
            }
            return "shouldnt happend";
        }

        private static string ProcessPacket(JsonNode raw, IServiceProvider serviceProvider)
        {
            var rawPacket = raw.Deserialize<RawPacket>();

            if (!CommandsMapper.TryGetValue(rawPacket.Method, out var endpointMapping))
            {
                throw new Exception("Unsupported Packet");
            }

            var result = endpointMapping(rawPacket, serviceProvider);

            return result;
        }

        internal static string CommandMapping<TEndpoint, TParams>(RawPacket rawPacket, IServiceProvider serviceProvider) where TEndpoint : BaseCommandHandler<TParams>
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
