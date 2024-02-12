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
            var info = DatabaseManager.GameVersionInfo.Get(@params.ch);

            double policy = Convert.ToDouble(info.showPolicy);
            int fileCheckingEnabled = Convert.ToInt32(info.fileCheck);
            int googleLoginEnabled = Convert.ToInt32(info.enableGoogleLogin);
            int isVersionOutdated = Convert.ToInt32(info.Version_State);

            GameVersionInfoResponse gameversion = new()
            {
                policy = policy,
                chat = info.Chat_Url,
                cdn = info.Cdn_Url,
                game = info.Game_Url,
                fc = fileCheckingEnabled,
                gglogin = googleLoginEnabled,
                ver = info.Version,
                word = info.Word,
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