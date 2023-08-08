using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Dispatch
{
    [Command(Id = CommandId.GetExplorationList)]
    public class GetExplorationList : BaseCommandHandler<GetExplorationListRequest>
    {

        public override object Handle(GetExplorationListRequest @params)
        {
            ResponsePacket response = new();

            List<string> cids = new();


            List<ExplorationData> GetExplorationList1 = new()
            {

            };

            response.result = GetExplorationList1;
            response.id = BasePacket.Id;

            return response;
        }
    }


    public class GetExplorationListRequest
    {

    }
}