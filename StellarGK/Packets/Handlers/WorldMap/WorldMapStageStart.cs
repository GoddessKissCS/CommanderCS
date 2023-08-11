using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.WorldMap
{
    [Command(Id = CommandId.WorldMapStageStart)]
    public class WorldMapStageStart : BaseCommandHandler<WorldMapStageStartRequest>
    {
        public override object Handle(WorldMapStageStartRequest @params)
        {
            ResponsePacket response = new();

            WorldMapStageStartRes wmssr = new();

            List<RewardInfo.RewardData> test = new();

            wmssr.reward = test;

            wmssr.rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(GetSession());

            response.id = BasePacket.Id;
            response.result = wmssr;


            return response;
        }

        public class WorldMapStageStartRes
        {
            [JsonPropertyName("rsoc")]
            public UserInformationResponse.Resource rsoc { get; set; }
            [JsonPropertyName("reward")]
            public List<RewardInfo.RewardData> reward { get; set; }
        }

    }

    public class WorldMapStageStartRequest
    {

    }
}
