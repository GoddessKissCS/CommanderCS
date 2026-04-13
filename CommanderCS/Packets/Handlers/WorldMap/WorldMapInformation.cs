using CommanderCS.Library.Enums;
using CommanderCS.Library.Packets.Structure;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapInformation)]
    public class WorldMapInformation : BaseMethodHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            string worldId = request.world.ToString();

            User.BattleData.WorldMapStages.TryGetValue(worldId, out List<WorldMapInformationResponse> stages);
            User.BattleData.WorldMapStageReward.TryGetValue(worldId, out int isRewardCollected);

            WorldMapResponse worldmap = new()
            {
                stage = stages,
                rwd = isRewardCollected,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = worldmap
            };

            return response;
        }
    }
}