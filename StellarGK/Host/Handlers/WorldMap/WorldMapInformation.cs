using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Database.Models;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.WorldMap
{
    [Command(Id = CommandId.WorldMapInformation)]
    public class WorldMapInformation : BaseCommandHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest @params)
        {
            // TODO ???

            GameDataScheme resources = DatabaseManager.GameData.FindBySession(BasePacket.Session);

            resources.stages.TryGetValue(@params.world.ToString(), out List<WorldMapInformationResponse> worldMapStages);

            WorldMapResponse worldmap = new()
            {
                stage = worldMapStages,
                rwd = 0
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = worldmap
            };

            return response;
        }
    }
    public class WorldMapInformationRequest
    {
        [JsonPropertyName("world")]
        public int world { get; set; }
    }

    public class WorldMapResponse
    {
        [JsonPropertyName("stage")]
        public List<WorldMapInformationResponse> stage { get; set; }
        [JsonPropertyName("rwd")]
        public int rwd { get; set; }
    }
}