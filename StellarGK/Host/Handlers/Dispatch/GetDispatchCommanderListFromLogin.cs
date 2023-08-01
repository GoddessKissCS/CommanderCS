using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Dispatch
{
    [Command(Id = CommandId.GetDispatchCommanderListFromLogin)]
    public class GetDispatchCommanderListFromLogin : BaseCommandHandler<GetDispatchCommanderListFromLoginRequest>
    {

        public override string Handle(GetDispatchCommanderListFromLoginRequest @params)
        {
            var resources = DatabaseManager.GameData.FindBySession(BasePacket.Session);

            ResponsePacket responsePacket = new()
            {
                id = BasePacket.Id,
                result = resources.dispatchedCommanders,
            };

            return JsonConvert.SerializeObject(responsePacket);
        }


    }
    public class GetDispatchCommanderListFromLoginRequest
    {

    }
}