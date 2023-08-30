using Newtonsoft.Json;
using StellarGKLibrary.Protocols;

namespace StellarGK.Host.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapInformation)]
    public class WorldMapInformation : BaseMethodHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest @params)
        {
#warning TODO ???

            var user = GetUserGameProfile();

            user.WorldMapStages.TryGetValue(@params.world.ToString(), out List<WorldMapInformationResponse> worldMapStages);

            user.WorldMapStagesReward.TryGetValue(@params.world.ToString(), out int rwd);

            // reward means if you complete the stage
            // maybe needs a rework if you already have it?
            // need to add if you already have all and add it to the db

            WorldMapResponse worldmap = new()
            {
                stage = worldMapStages,
                rwd = Convert.ToInt32(rwd),
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
        [JsonProperty("world")]
        public int world { get; set; }
    }

    public class WorldMapResponse
    {
        [JsonProperty("stage")]
        public List<WorldMapInformationResponse> stage { get; set; }
        [JsonProperty("rwd")]
        public int rwd { get; set; }
    }
}