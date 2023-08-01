using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Models
{
    public class DormitoryScheme
    {
        public int Id { get; set; }
        public Dictionary<string, int> dormitoryInfo { get; set; }
        public Dormitory.Resource dormitoryResource { get; set; }
        public Dictionary<string, int> itemNormal { get; set; }
        public Dictionary<string, int> itemAdvanced { get; set; }
        public Dictionary<string, int> itemWallpaper { get; set; }
        public Dictionary<string, int> costumeBody { get; set; }
        public Dictionary<string, List<string>> costumeHead { get; set; }
    }
}
