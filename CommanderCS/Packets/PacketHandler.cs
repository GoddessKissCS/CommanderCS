using CommanderCSLibrary.Cryptography;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.Design;

namespace CommanderCS.Host
{
    public partial class PacketHandler
    {
        /// <summary>
        /// Processes an incoming HTTP request, decrypts and decompresses the payload,
        /// processes the JSON data, and returns an encrypted response.
        /// </summary>
        /// <param name="context">The HTTP context containing the request information.</param>
        /// <param name="serviceProvider">The service provider used for dependency injection.</param>
        /// <returns>An encrypted string representing the processed response.</returns>
        public static async Task<string> ProcessRequest(HttpContext context, IServiceProvider serviceProvider)
        {
            var rawRequest = await Compression.Stream2ByteArray(context.Request.Body);

            var decompressedRequest = Compression.Decompress(rawRequest);

            var keyIndex = Crypto.Decrypt(decompressedRequest, out var decryptedRequest);

            var node = JsonConvert.DeserializeObject<JToken>(decryptedRequest);

            if (node is null)
            {
                return null;
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
            } else {
                response = ProcessPacket(node, serviceProvider);
            }

            if (response == "{}")
            {
                string res = response.ToString();
                res = Crypto.Encrypt(res, keyIndex);
                return res;
            }

            var serialized = JsonConvert.SerializeObject(response);

            var encrypted = Crypto.Encrypt(serialized, keyIndex);

            return encrypted;
        }

        /// <summary>
        /// Processes a JSON token representing a packet, retrieves corresponding endpoint mapping
        /// based on the packet's method, executes the mapped endpoint, and returns the result.
        /// </summary>
        /// <param name="raw">The JSON token representing the packet to be processed.</param>
        /// <param name="serviceProvider">The service provider used for dependency injection.</param>
        /// <returns>The result of the endpoint mapping execution.</returns>
        public static object ProcessPacket(JToken raw, IServiceProvider serviceProvider)
        {
            var paramsPacket = raw.ToObject<ParamsPacket>();

            if (!CommandsMapper.TryGetValue(paramsPacket.Method, out var endpointMapping))
            {
                var enumText = ((Method)paramsPacket.Method).ToString();

                throw new Exception("Unsupported Packet: " + enumText);
            }

            var result = endpointMapping(paramsPacket, serviceProvider);

            return result;
        }

        /// <summary>
        /// Maps a command to an endpoint handler, creates an instance of the endpoint handler,
        /// sets the ParamsPacket, executes the command handler, and returns the handled response.
        /// </summary>
        /// <typeparam name="TEndpoint">The type of the endpoint handler.</typeparam>
        /// <typeparam name="TParams">The type of the parameters passed to the endpoint handler.</typeparam>
        /// <param name="paramsPacket">The ParamsPacket containing the parameters for the command.</param>
        /// <param name="serviceProvider">The service provider used for dependency injection.</param>
        /// <returns>The response handled by the endpoint.</returns>
        internal static object CommandMapping<TEndpoint, TParams>(ParamsPacket paramsPacket, IServiceProvider serviceProvider) where TEndpoint : BaseMethodHandler<TParams>
        {
            var @params = paramsPacket.Params.ToObject<TParams>();

            var commandHandler = ActivatorUtilities.CreateInstance<TEndpoint>(serviceProvider);

            commandHandler.BasePacket = paramsPacket;

            object handledResponse = commandHandler.Handle(@params);

            return handledResponse;
        }

        /// <summary>
        /// Gets a list of commands mapped to their corresponding keys in the CommandsMapper dictionary.
        /// </summary>
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