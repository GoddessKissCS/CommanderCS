using CommanderCS.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapInformation)]
    public class WorldMapInformation : BaseMethodHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest @params)
        {
            var user = GetUserGameProfile();

            string worldId = @params.world.ToString();

            user.WorldMapData.Stages.TryGetValue(worldId, out List<WorldMapInformationResponse> stages);
            user.WorldMapData.StageReward.TryGetValue(worldId, out int isRewardCollected);

            WorldMapResponse worldmap = new()
            {
                stage = stages,
                rwd = Convert.ToInt32(isRewardCollected),
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