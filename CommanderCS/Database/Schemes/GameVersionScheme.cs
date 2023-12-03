using MongoDB.Bson;

namespace CommanderCS.Database.Schemes
{
    public class GameVersionScheme
    {
        public ObjectId Id { get; set; }
        public int ChannelId { get; set; }
        public string Version { get; set; }
        public bool Version_State { get; set; }
        public string Cdn_Url { get; set; }
        public string Game_Url { get; set; }
        public string Chat_Url { get; set; }
        public bool showPolicy { get; set; }
        public Dictionary<string, double> Word { get; set; }
        public bool fileCheck { get; set; }
        public bool enableGoogleLogin { get; set; }
    }
}