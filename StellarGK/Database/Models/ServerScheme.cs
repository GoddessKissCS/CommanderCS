namespace StellarGK.Database.Models
{
    public class ServerScheme
    {
        public int Id { get; set; }
        public double openDate { get; set; }
        public int maxLevel { get; set; }
        public string maxStage { get; set; }
        public int playerCount { get; set; }
        public int serverCount { get; set; }
    }
}
