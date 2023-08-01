using Org.BouncyCastle.Bcpg;
using StellarGK.Database;
using StellarGK.Host.Handlers.Nickname;
using StellarGK.Logic.Protocols;
using StellarGK2;

namespace StellarGK.Host.Handlers.Battle
{
    [Command(Id = CommandId.BattleOut)]
    public class BattleOut : BaseCommandHandler<BattleOutRequest>
    {
        public override string Handle(BattleOutRequest @params)
        {
            UserInformationResponse.BattleResult battleResult = new()
            {
                __resource = DatabaseManager.Resources.RequestResourcesScheme(BasePacket.Session),
            };

            throw new Exception();
            return "Example";
        }

    }

    public class BattleOutRequest
    {

    }
}
