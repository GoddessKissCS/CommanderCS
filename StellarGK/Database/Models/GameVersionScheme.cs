namespace StellarGK.Database.Models
{
    public class GameVersionScheme
    {
        public int Id { get; set; }
        public string version { get; set; }
        public bool versionStatus { get; set; }
        public string cdn_url { get; set; }
        public string game_url { get; set; }
        public string chat_url { get; set; }
        public bool showPolicy { get; set; }
        public Dictionary<string, double> word { get; set; }
        public bool fileCheck { get; set; }
        public bool enableGoogleLogin { get; set; }
    }
}
