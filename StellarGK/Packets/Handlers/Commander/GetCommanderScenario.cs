using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Commander
{
    [Command(Id = CommandId.GetCommanderScenario)]
    public class GetCommanderScenario : BaseCommandHandler<GetCommanderScenarioRequest>
    {
        public override object Handle(GetCommanderScenarioRequest @params)
        {
            ResponsePacket response = new();

            Dictionary<string, Dictionary<string, CommanderScenario>> result = new Dictionary<string, Dictionary<string, CommanderScenario>>();

            response.result = result;
            response.id = BasePacket.Id;

            return response;
        }

    }

    public class GetCommanderScenarioRequest
    {

    }
}