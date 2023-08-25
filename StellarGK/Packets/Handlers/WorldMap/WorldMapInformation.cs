using StellarGK.Logic.Protocols;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.WorldMap
{
    [Packet(MethodId.WorldMapInformation)]
    public class WorldMapInformation : BaseMethodHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest @params)
        {
#warning TODO ???

            GetUserGameProfile().Stages.TryGetValue(@params.world.ToString(), out List<WorldMapInformationResponse> worldMapStages);

            int rwd = Convert.ToInt32(worldMapStages.All(c => c.star == 3));

            // reward means if you complete the stage
            // maybe needs a rework if you already have it?
            // need to add if you already have all and add it to the db


            WorldMapResponse worldmap = new()
            {
                stage = worldMapStages,
                rwd = rwd,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = worldmap
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