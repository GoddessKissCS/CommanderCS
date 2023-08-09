using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.VersionCheck
{
    [Command(Id = CommandId.GameVersionInfo)]
    public class GameVersionInfo : BaseCommandHandler<GameVersionInfoRequest>
    {
        public override object Handle(GameVersionInfoRequest @params)
        {
            ResponsePacket ResponsePacket = new();

            var info = DatabaseManager.GameVersionInfo.Get(@params.ch);

            GameInfoToSent game = new()
            {
                policy = Convert.ToDouble(info.showPolicy),
                chat = info.chat_url,
                cdn = info.cdn_url,
                game = info.game_url,
                fc = Convert.ToInt32(info.fileCheck),
                gglogin = Convert.ToInt32(info.enableGoogleLogin),
                ver = info.version,
                word = info.word,
                stat = Convert.ToInt32(info.versionStatus)
            };

            ResponsePacket.id = BasePacket.Id;
            ResponsePacket.result = game;

            return ResponsePacket;
        }

        private class GameInfoToSent
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