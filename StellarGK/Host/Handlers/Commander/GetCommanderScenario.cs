using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using StellarGK.Host.Handlers.Nickname;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Commander
{
    [Command(Id = CommandId.GetCommanderScenario)]
    public class GetCommanderScenario : BaseCommandHandler<GetCommanderScenarioRequest>
    {
        public override string Handle(GetCommanderScenarioRequest @params)
        {
            GetCommanderScenarioPacket commanderScenario = new();

            Dictionary<string, Dictionary<string, CommanderScenario>> result = new Dictionary<string, Dictionary<string, CommanderScenario>>();

            commanderScenario.result = result;
            commanderScenario.id = BasePacket.Id;

            return JsonConvert.SerializeObject(commanderScenario);
        }

        public class GetCommanderScenarioPacket
        {
            public string id { get; set; }

            public Dictionary<string, Dictionary<string, CommanderScenario>> result { get; set; }
        }

    }

    public class GetCommanderScenarioRequest
    {

    }
}