using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.VersionCheck
{
    [Packet(Id = Method.GameVersionInfo)]
    public class GameVersionInfo : BaseMethodHandler<GameVersionInfoRequest>
    {
        public override object Handle(GameVersionInfoRequest @params)
        {
            var gameVer = DatabaseManager.GameVersionInfo.Get(@params.ch);
            double policy = Convert.ToDouble(gameVer.showPolicy);
            int fileCheckingEnabled = Convert.ToInt32(gameVer.fileCheck);
            int googleLoginEnabled = Convert.ToInt32(gameVer.enableGoogleLogin);
            int isVersionOutdated = Convert.ToInt32(gameVer.Version_State);

            GameVersionInfoResponse gameversion = new()
            {
                policy = policy,
                chat = gameVer.Chat_Url,
                cdn = gameVer.Cdn_Url,
                game = gameVer.Game_Url,
                fc = fileCheckingEnabled,
                gglogin = googleLoginEnabled,
                ver = gameVer.Version,
                word = gameVer.Word,
                stat = isVersionOutdated
            };

            ResponsePacket ResponsePacket = new()
            {
                Id = BasePacket.Id,
                Result = gameversion
            };

            return ResponsePacket;
        }

        private class GameVersionInfoResponse
        {
            [JsonProperty("ver")]
            public string ver { get; set; }

            [JsonProperty("stat")]
            public int stat { get; set; }

            [JsonProperty("cdn")]
            public string cdn { get; set; }

            [JsonProperty("game")]
            public string game { get; set; }

            [JsonProperty("chat")]
            public string chat { get; set; }

            [JsonProperty("policy")]
            public double policy { get; set; }

            [JsonProperty("word")]
            public Dictionary<string, double> word { get; set; }

            [JsonProperty("fc")]
            public int fc { get; set; }

            [JsonProperty("gglogin")]
            public int gglogin { get; set; }
        }
    }

    public class GameVersionInfoRequest
    {
        [JsonProperty("ch")]
        public int ch { get; set; }
    }
}