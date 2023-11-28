using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.ExcelReader;
using CommanderCS.Protocols;
using System.Security.Cryptography;

namespace CommanderCS.Host.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapInformation)]
    public class WorldMapInformation : BaseMethodHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest @params)
        {
            var user = GetUserGameProfile();

            user.WorldMapStages.TryGetValue(@params.world.ToString(), out List<WorldMapInformationResponse> stages);

            user.WorldMapStagesReward.TryGetValue(@params.world.ToString(), out int isRewardCollected);

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