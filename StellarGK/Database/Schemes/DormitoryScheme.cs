using MongoDB.Bson;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Schemes
{
    public class DormitoryScheme
    {
        public ObjectId Id { get; set; }
        public int memberId { get; set; }
        public Dictionary<string, int> dormitoryInfo { get; set; }
        public Dormitory.Resource dormitoryResource { get; set; }
        public Dictionary<string, int> itemNormal { get; set; }
        public Dictionary<string, int> itemAdvanced { get; set; }
        public Dictionary<string, int> itemWallpaper { get; set; }
        public Dictionary<string, int> costumeBody { get; set; }
        public Dictionary<string, List<string>> costumeHead { get; set; }
    }
}
