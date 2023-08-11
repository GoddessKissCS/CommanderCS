using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Battle
{
    [Command(Id = CommandId.BattleOut)]
    public class BattleOut : BaseCommandHandler<BattleOutRequest>
    {
        public override object Handle(BattleOutRequest @params)
        {

            UserInformationResponse.BattleResult battleResult = new()
            {
                __resource = DatabaseManager.GameProfile.UserResourcesFromSession(GetSession()),
            };

            throw new Exception();


        }

    }

    public class BattleOutRequest
    {

    }
}
