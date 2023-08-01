using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.VersionCheck
{
    [Command(Id = CommandId.GameVersionInfo)]
    public class GameVersionInfo : BaseCommandHandler<GameVersionInfoRequest>
    {
        public override string Handle(GameVersionInfoRequest @params)
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

            return JsonConvert.SerializeObject(ResponsePacket);
        }

        private class GameInfoToSent
        {
            public string ver { get; set; }
            public int stat { get; set; }
            public string cdn { get; set; }
            public string game { get; set; }
            public string chat { get; set; }
            public double policy { get; set; }
            public Dictionary<string, double> word { get; set; }
            public int fc { get; set; }
            public int gglogin { get; set; }
        }

    }

    public class GameVersionInfoRequest
    {
        [JsonProperty("ch")]
        public int ch { get; set; }
    }
}