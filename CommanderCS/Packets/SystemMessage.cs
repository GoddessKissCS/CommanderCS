using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host
{
    /// <summary>
    /// Represents a SystemMessagePacket template.
    /// <para>Id is set to "system", so the client knows it's a SystemMessage Packet.</para>
    /// <para>Result contains a SystemMessage object, see <see cref="SystemMessage"/>.</para>
    /// </summary>
    public class SystemPacket
    {
        /// <summary>
        /// Gets or sets the identifier of the SystemPacket, set to "system".
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; } = "system";

        /// <summary>
        /// Gets or sets the SystemMessage object contained in the SystemPacket result.
        /// </summary>
        [JsonProperty("result")]
        public SystemMessage Result { get; set; }
    }
}