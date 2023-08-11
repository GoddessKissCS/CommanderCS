using System.Text.Json.Serialization;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.WorldMap
{
    [Command(Id = CommandId.WorldMapInformation)]
    public class WorldMapInformation : BaseCommandHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest @params)
        {
            // TODO ???

            GetGameProfile().stages.TryGetValue(@params.world.ToString(), out List<WorldMapInformationResponse> worldMapStages);

            bool reward = worldMapStages.All(c => c.star == 3); 

            // reward means if you complete the stage
            // maybe needs a rework if you already have it?

            WorldMapResponse worldmap = new()
            {
                stage = worldMapStages,
                rwd = Convert.ToInt32(reward) 
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