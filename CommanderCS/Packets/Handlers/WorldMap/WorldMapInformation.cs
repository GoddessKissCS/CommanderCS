using CommanderCS.Library.Packets.Structure;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;

namespace CommanderCS.Host.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapInformation)]
    public class WorldMapInformation : BaseMethodHandler<WorldMapInformationRequest>
    {
        public override object Handle(WorldMapInformationRequest @params)
        {
            string worldId = @params.world.ToString();

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