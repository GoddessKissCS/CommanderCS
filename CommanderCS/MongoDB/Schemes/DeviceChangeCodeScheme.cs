using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a device change code scheme used for device change verification.
    /// </summary>
    public class DeviceChangeCodeScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the device change code scheme.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the member ID associated with the device change code.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the code used for device change verification.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the code was created.
        /// </summary>
        public long CreateTime { get; set; }
    }
}