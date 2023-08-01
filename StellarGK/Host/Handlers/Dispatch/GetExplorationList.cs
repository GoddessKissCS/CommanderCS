using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using StellarGK.Host.Handlers.Nickname;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Dispatch
{
    [Command(Id = CommandId.GetExplorationList)]
    public class GetExplorationList : BaseCommandHandler<GetExplorationListRequest>
    {

        public override string Handle(GetExplorationListRequest @params)
        {
            GetExplorationListPacket GetExplorationList = new();

            List<string> cids = new();

            List<ExplorationData> GetExplorationList1 = new()
            {

            };

            GetExplorationList.result = GetExplorationList1;
            GetExplorationList.id = BasePacket.Id;

            return JsonConvert.SerializeObject(GetExplorationList);
        }
    }

    public class GetExplorationListPacket
    {
        public string id { get; set; }

        public List<ExplorationData> result { get; set; }
    }

    public class GetExplorationListRequest
    {

    }
}