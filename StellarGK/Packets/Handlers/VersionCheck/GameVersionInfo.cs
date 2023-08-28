using StellarGK.Database;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.VersionCheck
{
    [Packet(Id = Method.GameVersionInfo)]
    public class GameVersionInfo : BaseMethodHandler<GameVersionInfoRequest>
    {
        public override object Handle(GameVersionInfoRequest @params)
        {
            ResponsePacket ResponsePacket = new();

            var info = DatabaseManager.GameVersionInfo.Get(@params.ch);

            GameInfoToSent game = new()
            {
                policy = Convert.ToDouble(info.showPolicy),
                chat = info.Chat_Url,
                cdn = info.Cdn_Url,
                game = info.Game_Url,
                fc = Convert.ToInt32(info.fileCheck),
                gglogin = Convert.ToInt32(info.enableGoogleLogin),
                ver = info.Version,
                word = info.Word,
                stat = Convert.ToInt32(info.Version_State)
            };

            ResponsePacket.Id = BasePacket.Id;
            ResponsePacket.Result = game;

            return ResponsePacket;
        }

        internal class GameInfoToSent
        {
            [JsonPropertyName("ver")]
            public string ver { get; set; }
            [JsonPropertyName("stat")]
            public int stat { get; set; }
            [JsonPropertyName("cdn")]
            public string cdn { get; set; }
            [JsonPropertyName("game")]
            public string game { get; set; }
            [JsonPropertyName("chat")]
            public string chat { get; set; }
            [JsonPropertyName("policy")]
            public double policy { get; set; }
            [JsonPropertyName("word")]
            public Dictionary<string, double> word { get; set; }
            [JsonPropertyName("fc")]
            public int fc { get; set; }
            [JsonPropertyName("gglogin")]
            public int gglogin { get; set; }
        }

    }

    public class GameVersionInfoRequest
    {
        [JsonPropertyName("ch")]
        public int ch { get; set; }
    }
}