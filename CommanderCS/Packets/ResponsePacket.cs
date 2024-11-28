using Newtonsoft.Json;

namespace CommanderCS.Host
{
    /// <summary>
    /// Represents a response packet containing an identifier and a result.
    /// </summary>
    public class ResponsePacket
    {
        /// <summary>
        /// Gets or sets the identifier of the response packet.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the result of the response packet.
        /// </summary>
        [JsonProperty("result")]
        public object Result { get; set; }
    }
}