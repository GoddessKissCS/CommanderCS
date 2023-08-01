using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.WorldMap
{
    [Command(Id = CommandId.WorldMapStageStart)]
    public class WorldMapStageStart : BaseCommandHandler<WorldMapStageStartRequest>
    {
        public override string Handle(WorldMapStageStartRequest @params)
        {
            ResponsePacket response = new();

            WorldMapStageStartRes wmssr = new();

            List<RewardInfo.RewardData> test = new();

            wmssr.reward = test;

            var resources = DatabaseManager.Resources.FindBySession(BasePacket.Session);

            wmssr.rsoc = DatabaseManager.Resources.ResourcesSchemeToUserInformationResource(resources);

            response.id = BasePacket.Id;
            response.result = wmssr;


            return JsonConvert.SerializeObject(response);
        }

        public class WorldMapStageStartRes
        {
            public UserInformationResponse.Resource rsoc { get; set; }
            public List<RewardInfo.RewardData> reward { get; set; }
        }

    }

    public class WorldMapStageStartRequest
    {

    }
}
