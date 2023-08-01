namespace StellarGK.Database.Models
{
    public class GameVersionScheme
    {
        public int Id { get; set; }
        public string ver { get; set; }
        public bool stat { get; set; }
        public string cdn { get; set; }
        public string game { get; set; }
        public string chat { get; set; }
        public bool policy { get; set; }
        public Dictionary<string, double> word { get; set; }
        public bool fc { get; set; }
        public bool gglogin { get; set; }
    }
}
