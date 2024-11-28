using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a dormitory scheme.
    /// </summary>
    public class DormitoryScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the dormitory scheme.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the Uno associated with the dormitory.
        /// </summary>
        public int Uno { get; set; }

        /// <summary>
        /// Gets or sets the dormitory information.
        /// </summary>
        public Dictionary<string, int> DormitoryInfo { get; set; }

        /// <summary>
        /// Gets or sets the dormitory resources.
        /// </summary>
        public Dormitory.Resource DormitoryResource { get; set; }

        /// <summary>
        /// Gets or sets the normal items in the dormitory.
        /// </summary>
        public Dictionary<string, int> ItemNormal { get; set; }

        /// <summary>
        /// Gets or sets the advanced items in the dormitory.
        /// </summary>
        public Dictionary<string, int> ItemAdvanced { get; set; }

        /// <summary>
        /// Gets or sets the wallpaper items in the dormitory.
        /// </summary>
        public Dictionary<string, int> ItemWallpaper { get; set; }

        /// <summary>
        /// Gets or sets the body costumes in the dormitory.
        /// </summary>
        public Dictionary<string, int> CostumeBody { get; set; }

        /// <summary>
        /// Gets or sets the head costumes in the dormitory.
        /// </summary>
        public Dictionary<string, List<string>> CostumeHead { get; set; }
    }
}