using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Battle
{
    [Command(Id = CommandId.BattleOut)]
    public class BattleOut : BaseCommandHandler<BattleOutRequest>
    {
        public override object Handle(BattleOutRequest @params)
        {

            return "{}";
        }

    }

    public class BattleOutRequest
    {
        [JsonPropertyName("type")]
        public int type { get; set; }
        [JsonPropertyName("checkSum")]
        public string checkSum { get; set; }
        [JsonPropertyName("info")]
        public JArray info { get; set; }
        [JsonPropertyName("result")]
        public JArray result { get; set; }
    }
}
