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
                policy = Convert.ToDouble(info.policy),
                chat = info.chat,
                cdn = info.cdn,
                game = info.game,
                fc = Convert.ToInt32(info.fc),
                gglogin = Convert.ToInt32(info.gglogin),
                ver = info.ver,
                word = info.word,
                stat = Convert.ToInt32(info.stat)
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